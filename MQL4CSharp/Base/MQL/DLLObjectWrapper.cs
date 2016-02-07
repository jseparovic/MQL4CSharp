/*
Copyright 2016 Jason Separovic

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using log4net;
using MQL4CSharp.Base.REST;
using RGiesecke.DllExport;


namespace MQL4CSharp.Base.MQL
{
    /// <summary>
    /// This class will be used to keep object refs so DLL calls are made to the correct object
    /// </summary>
    public class DLLObjectWrapper
    {
        public static int DEFAULT_CHART_ID = 0;

        private static readonly ILog LOG = LogManager.GetLogger(typeof(DLLObjectWrapper));

        private static DLLObjectWrapper dllObjectWrapper;

        private static readonly object syncLock = new object();

        private long restCommandLock;

        public static DLLObjectWrapper getInstance()
        {
            lock (syncLock)
            {
                if (dllObjectWrapper == null)
                {
                    dllObjectWrapper = new DLLObjectWrapper();
                }
            }
            return dllObjectWrapper;
        }

        private Dictionary<Int64, MQLCommandManager> mqlCommandManagers;
        private Dictionary<Int64, MQLExpert> mqlExperts;
        private Dictionary<Int64, MQLThreadPool> mqlThreadPools;

        private int mqlExpertsIx;

        private readonly object mqlCommandManagersLock;
        private readonly object mqlExpertsLock;

        private MQLRESTServer restServer;

        private DLLObjectWrapper()
        {
            restCommandLock = 0;
            mqlExperts = new Dictionary<Int64, MQLExpert>();
            mqlCommandManagers = new Dictionary<Int64, MQLCommandManager>();
            mqlThreadPools = new Dictionary<Int64, MQLThreadPool>();
            mqlExpertsLock = new object();
            restServer = new MQLRESTServer();

            // create the default command manager for REST
            // Only need to use chart specific one for ChartObjects
            mqlCommandManagers[DEFAULT_CHART_ID] = new MQLCommandManager(DEFAULT_CHART_ID);
        }

        public MQLCommandManager getMQLCommandManager(Int64 ix)
        {
            if (mqlCommandManagers.ContainsKey(ix))
            {
                return mqlCommandManagers[ix];
            }
            else
            {
                throw new Exception("MQLCommandManager does not exist");
            }
        }

        [DllExport("IsCommandManagerReady", CallingConvention = CallingConvention.StdCall)]
        public static bool IsCommandManagerReady(Int64 ix)
        {
            if (getInstance().mqlCommandManagers.ContainsKey(ix))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public MQLExpert getMQLExpert(Int64 ix)
        {
            if (mqlExperts.ContainsKey(ix))
            {
                return mqlExperts[ix];
            }
            else
            {
                throw new Exception("MQLExpert does not exist");
            }
        }

        public MQLThreadPool getMQLThreadPool(Int64 ix)
        {
            if (mqlThreadPools.ContainsKey(ix))
            {
                return mqlThreadPools[ix];
            }
            else
            {
                throw new Exception("MQLThreadPool does not exist");
            }
        }

        public void initMQLThreadPool(Int64 ix)
        {
            lock (mqlExpertsLock)
            {
                try
                {
                    mqlThreadPools[ix] = new MQLThreadPool(ix);
                }
                catch (Exception e)
                {
                    LOG.Error(e);
                }
            }
        }

        public void initMQLExpert(Int64 ix, String typeName)
        {
            lock (mqlExpertsLock)
            {
                try
                {
                    mqlCommandManagers[ix] = new MQLCommandManager(ix);
                    mqlExperts[ix] = (MQLExpert)Activator.CreateInstance(Type.GetType(typeName), ix);
                }
                catch (Exception e)
                {
                    LOG.Error(e);
                }
            }
        }


        [DllExport("RESTCommandLock", CallingConvention = CallingConvention.StdCall)]
        public static bool RestCommandLock(Int64 ix)
        {
            LOG.Info("lock requested: " + ix);
            try
            {
                lock (syncLock)
                {
                    if (getInstance().restCommandLock == 0)
                    {
                        LOG.Info("lock succeeded: " + ix);
                        getInstance().restCommandLock = ix;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return false;
            }
        }


        [DllExport("RESTCommandUnlock", CallingConvention = CallingConvention.StdCall)]
        public static bool RestCommandUnLock(Int64 ix)
        {
            LOG.Info("unlock requested: " + ix);
            try
            {
                lock (syncLock)
                {
                    if (getInstance().restCommandLock == ix)
                    {
                        getInstance().restCommandLock = 0;
                        LOG.Info("unlock succeeded: " + ix);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return false;
            }
        }

    }
}
