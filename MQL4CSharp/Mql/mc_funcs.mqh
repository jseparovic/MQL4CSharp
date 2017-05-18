


bool executeBoolCommand(int id, string params[])
{
   switch(id)
   {
      case 3:
         return SendFTP(params[0], params[1]);
      case 4:
         return SendNotification(params[0]);
      case 5:
         return SendMail(params[0], params[1]);
      case 26:
         return IsStopped();
      case 38:
         return IsConnected();
      case 39:
         return IsDemo();
      case 40:
         return IsDllsAllowed();
      case 41:
         return IsExpertEnabled();
      case 42:
         return IsLibrariesAllowed();
      case 43:
         return IsOptimization();
      case 44:
         return IsTesting();
      case 45:
         return IsTradeAllowed();
      case 46:
         return IsTradeAllowed(params[0], StringToTime(params[1]));
      case 47:
         return IsTradeContextBusy();
      case 48:
         return IsVisualMode();
      case 55:
         return SymbolSelect(params[0], StringCompare(params[1],"true",false)==0);
      case 56:
         return RefreshRates();
      case 69:
         return ChartApplyTemplate(StringToInteger(params[0]), params[1]);
      case 70:
         return ChartSaveTemplate(StringToInteger(params[0]), params[1]);
      case 76:
         return ChartClose(StringToInteger(params[0]));
      case 79:
         return ChartSetDouble(StringToInteger(params[0]), StrToInteger(params[1]), StringToDouble(params[2]));
      case 80:
         return ChartSetInteger(StringToInteger(params[0]), StrToInteger(params[1]), StringToInteger(params[2]));
      case 81:
         return ChartSetInteger(StringToInteger(params[0]), StrToInteger(params[1]), StringToInteger(params[3]));
      case 82:
         return ChartSetString(StringToInteger(params[0]), StrToInteger(params[1]), params[2]);
      case 83:
         return ChartNavigate(StringToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 85:
         return ChartIndicatorDelete(StringToInteger(params[0]), StrToInteger(params[1]), params[2]);
      case 93:
         return ChartSetSymbolPeriod(StringToInteger(params[0]), params[1], CONVERT_ENUM_TIMEFRAMES(params[2]));
      case 94:
         return ChartScreenShot(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]), CONVERT_ENUM_ALIGN_MODE(params[4]));
      case 106:
         return WindowScreenShot(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]));
      case 111:
         return OrderClose(StrToInteger(params[0]), StringToDouble(params[1]), StringToDouble(params[2]), StrToInteger(params[3]), CONVERT_COLOR(params[4]));
      case 112:
         return OrderCloseBy(StrToInteger(params[0]), StrToInteger(params[1]), CONVERT_COLOR(params[2]));
      case 117:
         return OrderDelete(StrToInteger(params[0]), CONVERT_COLOR(params[1]));
      case 121:
         return OrderModify(StrToInteger(params[0]), StringToDouble(params[1]), StringToDouble(params[2]), StringToDouble(params[3]), StringToTime(params[4]), CONVERT_COLOR(params[5]));
      case 126:
         return OrderSelect(StrToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 139:
         return SignalBaseSelect(StrToInteger(params[0]));
      case 144:
         return SignalInfoSetDouble(CONVERT_ENUM_SIGNAL_INFO_DOUBLE(params[0]), StringToDouble(params[1]));
      case 145:
         return SignalInfoSetInteger(CONVERT_ENUM_SIGNAL_INFO_INTEGER(params[0]), StringToInteger(params[1]));
      case 146:
         return SignalSubscribe(StringToInteger(params[0]));
      case 147:
         return SignalUnsubscribe();
      case 148:
         return GlobalVariableCheck(params[0]);
      case 150:
         return GlobalVariableDel(params[0]);
      case 155:
         return GlobalVariableTemp(params[0]);
      case 156:
         return GlobalVariableSetOnCondition(params[0], StringToDouble(params[1]), StringToDouble(params[2]));
      case 160:
         return IndicatorSetDouble(StrToInteger(params[0]), StringToDouble(params[1]));
      case 161:
         return IndicatorSetDouble(StrToInteger(params[0]), StrToInteger(params[1]), StringToDouble(params[2]));
      case 162:
         return IndicatorSetInteger(StrToInteger(params[0]), StrToInteger(params[1]));
      case 163:
         return IndicatorSetInteger(StrToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 164:
         return IndicatorSetString(StrToInteger(params[0]), params[1]);
      case 165:
         return IndicatorSetString(StrToInteger(params[0]), StrToInteger(params[1]), params[2]);
      case 166:
         return IndicatorBuffers(StrToInteger(params[0]));
      case 178:
         return ObjectCreate(StringToInteger(params[0]), params[1], CONVERT_ENUM_OBJECT(params[2]), StrToInteger(params[3]), StringToTime(params[4]), StringToDouble(params[5]), StringToTime(params[6]), StringToDouble(params[7]));
      case 179:
         return ObjectCreate(params[0], CONVERT_ENUM_OBJECT(params[1]), StrToInteger(params[2]), StringToTime(params[3]), StringToDouble(params[4]), StringToTime(params[5]), StringToDouble(params[6]), StringToTime(params[7]), StringToDouble(params[8]));
      case 1001:
         return ObjectCreate(params[0], CONVERT_ENUM_OBJECT(params[1]), StrToInteger(params[2]), StringToTime(params[3]), StringToDouble(params[4]));
      case 181:
         return ObjectDelete(StringToInteger(params[0]), params[1]);
      case 182:
         return ObjectDelete(params[0]);
      case 190:
         return ObjectMove(params[0], StrToInteger(params[1]), StringToTime(params[2]), StringToDouble(params[3]));
      case 196:
         return ObjectSetDouble(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StringToDouble(params[3]));
      case 197:
         return ObjectSetDouble(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]), StringToDouble(params[4]));
      case 198:
         return ObjectSetInteger(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StringToInteger(params[3]));
      case 199:
         return ObjectSetInteger(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]), StringToInteger(params[4]));
      case 200:
         return ObjectSetString(StringToInteger(params[0]), params[1], StrToInteger(params[2]), params[3]);
      case 201:
         return ObjectSetString(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]), params[4]);
      case 202:
         return TextSetFont(params[0], StrToInteger(params[1]), StrToInteger(params[3]));
      case 208:
         return ObjectSet(params[0], StrToInteger(params[1]), StringToDouble(params[2]));
      case 209:
         return ObjectSetFiboDescription(params[0], StrToInteger(params[1]), params[2]);
      case 210:
         return ObjectSetText(params[0], params[1], StrToInteger(params[2]), params[3], CONVERT_COLOR(params[4]));
   }
}

double executeDoubleCommand(int id, string params[])
{
   switch(id)
   {
      case 6:
         return AccountInfoDouble(StrToInteger(params[0]));
      case 9:
         return AccountBalance();
      case 10:
         return AccountCredit();
      case 13:
         return AccountEquity();
      case 14:
         return AccountFreeMargin();
      case 15:
         return AccountFreeMarginCheck(params[0], StrToInteger(params[1]), StringToDouble(params[2]));
      case 16:
         return AccountFreeMarginMode();
      case 18:
         return AccountMargin();
      case 21:
         return AccountProfit();
      case 32:
         return TerminalInfoDouble(StrToInteger(params[0]));
      case 37:
         return Point();
      case 52:
         return MarketInfo(params[0], StrToInteger(params[1]));
      case 61:
         return iClose(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 62:
         return iHigh(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 64:
         return iLow(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 66:
         return iOpen(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 89:
         return ChartPriceOnDropped();
      case 104:
         return WindowPriceOnDropped();
      case 113:
         return OrderClosePrice();
      case 116:
         return OrderCommission();
      case 119:
         return OrderLots();
      case 122:
         return OrderOpenPrice();
      case 125:
         return OrderProfit();
      case 129:
         return OrderStopLoss();
      case 131:
         return OrderSwap();
      case 133:
         return OrderTakeProfit();
      case 136:
         return SignalBaseGetDouble(CONVERT_ENUM_SIGNAL_BASE_DOUBLE(params[0]));
      case 141:
         return SignalInfoGetDouble(CONVERT_ENUM_SIGNAL_INFO_DOUBLE(params[0]));
      case 151:
         return GlobalVariableGet(params[0]);
      case 189:
         return ObjectGetValueByTime(StringToInteger(params[0]), params[1], StringToTime(params[2]), StrToInteger(params[3]));
      case 193:
         return ObjectGetDouble(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]));
      case 204:
         return ObjectGet(params[0], StrToInteger(params[1]));
      case 207:
         return ObjectGetValueByShift(params[0], StrToInteger(params[1]));
      case 212:
         return iAC(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 213:
         return iAD(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 214:
         return iADX(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]));
      case 215:
         return iAlligator(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]), StrToInteger(params[8]), StrToInteger(params[9]), StrToInteger(params[10]), StrToInteger(params[11]));
      case 216:
         return iAO(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 217:
         return iATR(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 218:
         return iBearsPower(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 219:
         return iBands(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StringToDouble(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]));
      case 220:
         return iBullsPower(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 221:
         return iCCI(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 222:
         return iDeMarker(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 223:
         return iEnvelopes(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StringToDouble(params[6]), StrToInteger(params[7]), StrToInteger(params[8]));
      case 224:
         return iForce(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]));
      case 225:
         return iFractals(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 226:
         return iGator(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]), StrToInteger(params[8]), StrToInteger(params[9]), StrToInteger(params[10]), StrToInteger(params[11]));
      case 227:
         return iIchimoku(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]));
      case 228:
         return iBWMFI(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 229:
         return iMomentum(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 230:
         return iMFI(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 231:
         return iMA(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]));
      case 232:
         return iOsMA(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]));
      case 233:
         return iMACD(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]));
      case 234:
         return iOBV(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 235:
         return iSAR(params[0], StrToInteger(params[1]), StringToDouble(params[2]), StringToDouble(params[3]), StrToInteger(params[4]));
      case 236:
         return iRSI(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 237:
         return iRVI(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 238:
         return iStdDev(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]));
      case 239:
         return iStochastic(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]), StrToInteger(params[8]));
      case 240:
         return iWPR(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
   }
}

int executeIntCommand(int id, string params[])
{
   switch(id)
   {
      case 17:
         return AccountLeverage();
      case 20:
         return AccountNumber();
      case 23:
         return AccountStopoutLevel();
      case 24:
         return AccountStopoutMode();
      case 25:
         return GetLastError();
      case 27:
         return UninitializeReason();
      case 28:
         return MQLInfoInteger(StrToInteger(params[0]));
      case 31:
         return TerminalInfoInteger(StrToInteger(params[0]));
      case 35:
         return Period();
      case 36:
         return Digits();
      case 53:
         return SymbolsTotal(StringCompare(params[0],"true",false)==0);
      case 57:
         return Bars(params[0], CONVERT_ENUM_TIMEFRAMES(params[1]));
      case 58:
         return Bars(params[0], CONVERT_ENUM_TIMEFRAMES(params[1]), StringToTime(params[2]), StringToTime(params[3]));
      case 59:
         return iBars(params[0], StrToInteger(params[1]));
      case 60:
         return iBarShift(params[0], StrToInteger(params[1]), StringToTime(params[2]), StringCompare(params[3],"true",false)==0);
      case 63:
         return iHighest(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 65:
         return iLowest(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 71:
         return ChartWindowFind(StringToInteger(params[0]), params[1]);
      case 72:
         return ChartWindowFind();
      case 87:
         return ChartIndicatorsTotal(StringToInteger(params[0]), StrToInteger(params[1]));
      case 88:
         return ChartWindowOnDropped();
      case 91:
         return ChartXOnDropped();
      case 92:
         return ChartYOnDropped();
      case 95:
         return WindowBarsPerChart();
      case 97:
         return WindowFind(params[0]);
      case 98:
         return WindowFirstVisibleBar();
      case 99:
         return WindowHandle(params[0], StrToInteger(params[1]));
      case 100:
         return WindowIsVisible(StrToInteger(params[0]));
      case 101:
         return WindowOnDropped();
      case 102:
         return WindowPriceMax(StrToInteger(params[0]));
      case 103:
         return WindowPriceMin(StrToInteger(params[0]));
      case 108:
         return WindowsTotal();
      case 109:
         return WindowXOnDropped();
      case 110:
         return WindowYOnDropped();
      case 120:
         return OrderMagicNumber();
      case 127:
         return OrderSend(params[0], StrToInteger(params[1]), StringToDouble(params[2]), StringToDouble(params[3]), StrToInteger(params[4]), StringToDouble(params[5]), StringToDouble(params[6]), params[7], StrToInteger(params[8]), StringToTime(params[9]), CONVERT_COLOR(params[10]));
      case 128:
         return OrdersHistoryTotal();
      case 130:
         return OrdersTotal();
      case 134:
         return OrderTicket();
      case 135:
         return OrderType();
      case 140:
         return SignalBaseTotal();
      case 157:
         return GlobalVariablesDeleteAll(params[0], StringToTime(params[1]));
      case 158:
         return GlobalVariablesTotal();
      case 167:
         return IndicatorCounted();
      case 183:
         return ObjectsDeleteAll(StringToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 184:
         return ObjectsDeleteAll(StrToInteger(params[0]), StrToInteger(params[1]));
      case 185:
         return ObjectsDeleteAll(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]));
      case 186:
         return ObjectFind(StringToInteger(params[0]), params[1]);
      case 187:
         return ObjectFind(params[0]);
      case 191:
         return ObjectsTotal(StringToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 192:
         return ObjectsTotal(StrToInteger(params[0]));
      case 206:
         return ObjectGetShiftByValue(params[0], StringToDouble(params[1]));
      case 211:
         return ObjectType(params[0]);
   }
}

string executeStringCommand(int id, string params[])
{
   switch(id)
   {
      case 8:
         return AccountInfoString(StrToInteger(params[0]));
      case 11:
         return AccountCompany();
      case 12:
         return AccountCurrency();
      case 19:
         return AccountName();
      case 22:
         return AccountServer();
      case 29:
         return MQLInfoString(StrToInteger(params[0]));
      case 33:
         return TerminalInfoString(StrToInteger(params[0]));
      case 34:
         return Symbol();
      case 49:
         return TerminalCompany();
      case 50:
         return TerminalName();
      case 51:
         return TerminalPath();
      case 54:
         return SymbolName(StrToInteger(params[0]), StringCompare(params[1],"true",false)==0);
      case 77:
         return ChartSymbol(StringToInteger(params[0]));
      case 86:
         return ChartIndicatorName(StringToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 96:
         return WindowExpertName();
      case 115:
         return OrderComment();
      case 132:
         return OrderSymbol();
      case 138:
         return SignalBaseGetString(CONVERT_ENUM_SIGNAL_BASE_STRING(params[0]));
      case 143:
         return SignalInfoGetString(CONVERT_ENUM_SIGNAL_INFO_STRING(params[0]));
      case 152:
         return GlobalVariableName(StrToInteger(params[0]));
      case 180:
         return ObjectName(StrToInteger(params[0]));
      case 195:
         return ObjectGetString(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]));
      case 203:
         return ObjectDescription(params[0]);
      case 205:
         return ObjectGetFiboDescription(params[0], StrToInteger(params[1]));
   }
}

void executeVoidCommand(int id, string params[])
{
   switch(id)
   {
      case 1:
          Alert(params[0]);
      case 2:
          Comment(params[0]);
      case 30:
          MQLSetInteger(StrToInteger(params[0]), StrToInteger(params[1]));
      case 78:
          ChartRedraw(StringToInteger(params[0]));
      case 105:
          WindowRedraw();
      case 124:
          OrderPrint();
      case 154:
          GlobalVariablesFlush();
      case 159:
          HideTestIndicators(StringCompare(params[0],"true",false)==0);
      case 168:
          IndicatorDigits(StrToInteger(params[0]));
      case 169:
          IndicatorShortName(params[0]);
      case 170:
          SetIndexArrow(StrToInteger(params[0]), StrToInteger(params[1]));
      case 171:
          SetIndexDrawBegin(StrToInteger(params[0]), StrToInteger(params[1]));
      case 172:
          SetIndexEmptyValue(StrToInteger(params[0]), StringToDouble(params[1]));
      case 173:
          SetIndexLabel(StrToInteger(params[0]), params[1]);
      case 174:
          SetIndexShift(StrToInteger(params[0]), StrToInteger(params[1]));
      case 175:
          SetIndexStyle(StrToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), CONVERT_COLOR(params[4]));
      case 176:
          SetLevelStyle(StrToInteger(params[0]), StrToInteger(params[1]), CONVERT_COLOR(params[2]));
      case 177:
          SetLevelValue(StrToInteger(params[0]), StringToDouble(params[1]));
   }
}

long executeLongCommand(int id, string params[])
{
   switch(id)
   {
      case 7:
         return AccountInfoInteger(StrToInteger(params[0]));
      case 68:
         return iVolume(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 73:
         return ChartOpen(params[0], CONVERT_ENUM_TIMEFRAMES(params[1]));
      case 74:
         return ChartFirst();
      case 75:
         return ChartNext(StringToInteger(params[0]));
      case 84:
         return ChartID();
      case 137:
         return SignalBaseGetInteger(CONVERT_ENUM_SIGNAL_BASE_INTEGER(params[0]));
      case 142:
         return SignalInfoGetInteger(CONVERT_ENUM_SIGNAL_INFO_INTEGER(params[0]));
      case 194:
         return ObjectGetInteger(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]));
   }
}

datetime executeDateTimeCommand(int id, string params[])
{
   switch(id)
   {
      case 67:
         return iTime(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 90:
         return ChartTimeOnDropped();
      case 107:
         return WindowTimeOnDropped();
      case 114:
         return OrderCloseTime();
      case 118:
         return OrderExpiration();
      case 123:
         return OrderOpenTime();
      case 149:
         return GlobalVariableTime(params[0]);
      case 153:
         return GlobalVariableSet(params[0], StringToDouble(params[1]));
      case 188:
         return ObjectGetTimeByValue(params[0], StringToDouble(params[1]), StrToInteger(params[2]));
   }
}
