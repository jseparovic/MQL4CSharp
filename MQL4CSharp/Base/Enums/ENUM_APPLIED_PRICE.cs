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
    public enum ENUM_APPLIED_PRICE
    {
        PRICE_CLOSE	= 0, //	Close price
        PRICE_OPEN = 1, // Open price
        PRICE_HIGH = 2, // The maximum price for the period
        PRICE_LOW = 3, // The minimum price for the period
        PRICE_MEDIAN = 4, // Median price, (high + low)/2
        PRICE_TYPICAL = 5, // Typical price, (high + low + close)/3
        PRICE_WEIGHTED = 6, // Weighted close price, (high + low + close + close)/4

    }
}
