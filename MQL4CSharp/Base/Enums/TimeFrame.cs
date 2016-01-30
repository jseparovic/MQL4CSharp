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

namespace MQL4CSharp.Base.Enums
{
    public enum TIMEFRAME
    {
        PERIOD_CURRENT = 0,
        PERIOD_M1 = 1,
        PERIOD_M5 = 5,
        PERIOD_M15 = 15,
        PERIOD_M30 = 30,
        PERIOD_H1 = 60,
        PERIOD_H4 = 240,
        PERIOD_D1 = 1440,
        PERIOD_W1 = 10080,
        PERIOD_MN1 = 43200
    }
}
