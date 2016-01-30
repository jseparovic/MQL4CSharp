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
    public enum TRADE_OPERATION
    {
        OP_BUY = 0, // Buy operation
        OP_SELL = 1, // Sell operation
        OP_BUYLIMIT = 2,  //Buy limit pending order
        OP_SELLLIMIT = 3, // Sell limit pending order
        OP_BUYSTOP = 4, // Buy stop pending order
        OP_SELLSTOP = 5, // Sell stop pending order
    }
}
