
int CONVERT_ENUM_ALIGN_MODE(string value)
{
    if(value == "ALIGN_LEFT")
    {
        return ALIGN_LEFT;
    }
    else if(value == "ALIGN_CENTER")
    {
        return ALIGN_CENTER;
    }
    else if(value == "ALIGN_RIGHT")
    {
        return ALIGN_RIGHT;
    }
    else
    {
         return -1;
    }
}

int CONVERT_COLOR(string value)
{
    if(value == "NONE")
    {
        return clrNONE;
    }
    else if(value == "White")
    {
        return clrWhite;
    }
    else if(value == "Snow")
    {
        return clrSnow;
    }
    else if(value == "MintCream")
    {
        return clrMintCream;
    }
    else if(value == "LavenderBlush")
    {
        return clrLavenderBlush;
    }
    else if(value == "AliceBlue")
    {
        return clrAliceBlue;
    }
    else if(value == "Honeydew")
    {
        return clrHoneydew;
    }
    else if(value == "Ivory")
    {
        return clrIvory;
    }
    else if(value == "Seashell")
    {
        return clrSeashell;
    }
    else if(value == "WhiteSmoke")
    {
        return clrWhiteSmoke;
    }
    else if(value == "OldLace")
    {
        return clrOldLace;
    }
    else if(value == "MistyRose")
    {
        return clrMistyRose;
    }
    else if(value == "Lavender")
    {
        return clrLavender;
    }
    else if(value == "Linen")
    {
        return clrLinen;
    }
    else if(value == "LightCyan")
    {
        return clrLightCyan;
    }
    else if(value == "LightYellow")
    {
        return clrLightYellow;
    }
    else if(value == "Cornsilk")
    {
        return clrCornsilk;
    }
    else if(value == "PapayaWhip")
    {
        return clrPapayaWhip;
    }
    else if(value == "AntiqueWhite")
    {
        return clrAntiqueWhite;
    }
    else if(value == "Beige")
    {
        return clrBeige;
    }
    else if(value == "LemonChiffon")
    {
        return clrLemonChiffon;
    }
    else if(value == "BlanchedAlmond")
    {
        return clrBlanchedAlmond;
    }
    else if(value == "LightGoldenrod")
    {
        return clrLightGoldenrod;
    }
    else if(value == "Bisque")
    {
        return clrBisque;
    }
    else if(value == "Pink")
    {
        return clrPink;
    }
    else if(value == "PeachPuff")
    {
        return clrPeachPuff;
    }
    else if(value == "Gainsboro")
    {
        return clrGainsboro;
    }
    else if(value == "Moccasin")
    {
        return clrMoccasin;
    }
    else if(value == "NavajoWhite")
    {
        return clrNavajoWhite;
    }
    else if(value == "Wheat")
    {
        return clrWheat;
    }
    else if(value == "PaleTurquoise")
    {
        return clrPaleTurquoise;
    }
    else if(value == "PaleGoldenrod")
    {
        return clrPaleGoldenrod;
    }
    else if(value == "PowderBlue")
    {
        return clrPowderBlue;
    }
    else if(value == "Thistle")
    {
        return clrThistle;
    }
    else if(value == "PaleGreen")
    {
        return clrPaleGreen;
    }
    else if(value == "LightBlue")
    {
        return clrLightBlue;
    }
    else if(value == "LightSteelBlue")
    {
        return clrLightSteelBlue;
    }
    else if(value == "LightSkyBlue")
    {
        return clrLightSkyBlue;
    }
    else if(value == "Silver")
    {
        return clrSilver;
    }
    else if(value == "Aquamarine")
    {
        return clrAquamarine;
    }
    else if(value == "LightGreen")
    {
        return clrLightGreen;
    }
    else if(value == "Khaki")
    {
        return clrKhaki;
    }
    else if(value == "Plum")
    {
        return clrPlum;
    }
    else if(value == "LightSalmon")
    {
        return clrLightSalmon;
    }
    else if(value == "SkyBlue")
    {
        return clrSkyBlue;
    }
    else if(value == "LightCoral")
    {
        return clrLightCoral;
    }
    else if(value == "Violet")
    {
        return clrViolet;
    }
    else if(value == "Salmon")
    {
        return clrSalmon;
    }
    else if(value == "HotPink")
    {
        return clrHotPink;
    }
    else if(value == "BurlyWood")
    {
        return clrBurlyWood;
    }
    else if(value == "DarkSalmon")
    {
        return clrDarkSalmon;
    }
    else if(value == "Tan")
    {
        return clrTan;
    }
    else if(value == "MediumSlateBlue")
    {
        return clrMediumSlateBlue;
    }
    else if(value == "SandyBrown")
    {
        return clrSandyBrown;
    }
    else if(value == "DarkGray")
    {
        return clrDarkGray;
    }
    else if(value == "CornflowerBlue")
    {
        return clrCornflowerBlue;
    }
    else if(value == "Coral")
    {
        return clrCoral;
    }
    else if(value == "PaleVioletRed")
    {
        return clrPaleVioletRed;
    }
    else if(value == "MediumPurple")
    {
        return clrMediumPurple;
    }
    else if(value == "Orchid")
    {
        return clrOrchid;
    }
    else if(value == "RosyBrown")
    {
        return clrRosyBrown;
    }
    else if(value == "Tomato")
    {
        return clrTomato;
    }
    else if(value == "DarkSeaGreen")
    {
        return clrDarkSeaGreen;
    }
    else if(value == "MediumAquamarine")
    {
        return clrMediumAquamarine;
    }
    else if(value == "GreenYellow")
    {
        return clrGreenYellow;
    }
    else if(value == "MediumOrchid")
    {
        return clrMediumOrchid;
    }
    else if(value == "IndianRed")
    {
        return clrIndianRed;
    }
    else if(value == "DarkKhaki")
    {
        return clrDarkKhaki;
    }
    else if(value == "SlateBlue")
    {
        return clrSlateBlue;
    }
    else if(value == "RoyalBlue")
    {
        return clrRoyalBlue;
    }
    else if(value == "Turquoise")
    {
        return clrTurquoise;
    }
    else if(value == "DodgerBlue")
    {
        return clrDodgerBlue;
    }
    else if(value == "MediumTurquoise")
    {
        return clrMediumTurquoise;
    }
    else if(value == "DeepPink")
    {
        return clrDeepPink;
    }
    else if(value == "LightSlateGray")
    {
        return clrLightSlateGray;
    }
    else if(value == "BlueViolet")
    {
        return clrBlueViolet;
    }
    else if(value == "Peru")
    {
        return clrPeru;
    }
    else if(value == "SlateGray")
    {
        return clrSlateGray;
    }
    else if(value == "Gray")
    {
        return clrGray;
    }
    else if(value == "Red")
    {
        return clrRed;
    }
    else if(value == "Magenta")
    {
        return clrMagenta;
    }
    else if(value == "Blue")
    {
        return clrBlue;
    }
    else if(value == "DeepSkyBlue")
    {
        return clrDeepSkyBlue;
    }
    else if(value == "Aqua")
    {
        return clrAqua;
    }
    else if(value == "SpringGreen")
    {
        return clrSpringGreen;
    }
    else if(value == "Lime")
    {
        return clrLime;
    }
    else if(value == "Chartreuse")
    {
        return clrChartreuse;
    }
    else if(value == "Yellow")
    {
        return clrYellow;
    }
    else if(value == "Gold")
    {
        return clrGold;
    }
    else if(value == "Orange")
    {
        return clrOrange;
    }
    else if(value == "DarkOrange")
    {
        return clrDarkOrange;
    }
    else if(value == "OrangeRed")
    {
        return clrOrangeRed;
    }
    else if(value == "LimeGreen")
    {
        return clrLimeGreen;
    }
    else if(value == "YellowGreen")
    {
        return clrYellowGreen;
    }
    else if(value == "DarkOrchid")
    {
        return clrDarkOrchid;
    }
    else if(value == "CadetBlue")
    {
        return clrCadetBlue;
    }
    else if(value == "LawnGreen")
    {
        return clrLawnGreen;
    }
    else if(value == "MediumSpringGreen")
    {
        return clrMediumSpringGreen;
    }
    else if(value == "Goldenrod")
    {
        return clrGoldenrod;
    }
    else if(value == "SteelBlue")
    {
        return clrSteelBlue;
    }
    else if(value == "Crimson")
    {
        return clrCrimson;
    }
    else if(value == "Chocolate")
    {
        return clrChocolate;
    }
    else if(value == "MediumSeaGreen")
    {
        return clrMediumSeaGreen;
    }
    else if(value == "MediumVioletRed")
    {
        return clrMediumVioletRed;
    }
    else if(value == "FireBrick")
    {
        return clrFireBrick;
    }
    else if(value == "DarkViolet")
    {
        return clrDarkViolet;
    }
    else if(value == "LightSeaGreen")
    {
        return clrLightSeaGreen;
    }
    else if(value == "DimGray")
    {
        return clrDimGray;
    }
    else if(value == "DarkTurquoise")
    {
        return clrDarkTurquoise;
    }
    else if(value == "Brown")
    {
        return clrBrown;
    }
    else if(value == "MediumBlue")
    {
        return clrMediumBlue;
    }
    else if(value == "Sienna")
    {
        return clrSienna;
    }
    else if(value == "DarkSlateBlue")
    {
        return clrDarkSlateBlue;
    }
    else if(value == "DarkGoldenrod")
    {
        return clrDarkGoldenrod;
    }
    else if(value == "SeaGreen")
    {
        return clrSeaGreen;
    }
    else if(value == "ForestGreen")
    {
        return clrForestGreen;
    }
    else if(value == "SaddleBrown")
    {
        return clrSaddleBrown;
    }
    else if(value == "DarkOliveGreen")
    {
        return clrDarkOliveGreen;
    }
    else if(value == "DarkBlue")
    {
        return clrDarkBlue;
    }
    else if(value == "MidnightBlue")
    {
        return clrMidnightBlue;
    }
    else if(value == "Indigo")
    {
        return clrIndigo;
    }
    else if(value == "Maroon")
    {
        return clrMaroon;
    }
    else if(value == "Purple")
    {
        return clrPurple;
    }
    else if(value == "Navy")
    {
        return clrNavy;
    }
    else if(value == "Teal")
    {
        return clrTeal;
    }
    else if(value == "Green")
    {
        return clrGreen;
    }
    else if(value == "Olive")
    {
        return clrOlive;
    }
    else if(value == "DarkSlateGray")
    {
        return clrDarkSlateGray;
    }
    else if(value == "DarkGreen")
    {
        return clrDarkGreen;
    }
    else if(value == "Black")
    {
        return clrBlack;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_OBJECT(string value)
{
    if(value == "OBJ_VLINE")
    {
        return OBJ_VLINE;
    }
    else if(value == "OBJ_HLINE")
    {
        return OBJ_HLINE;
    }
    else if(value == "OBJ_TREND")
    {
        return OBJ_TREND;
    }
    else if(value == "OBJ_TRENDBYANGLE")
    {
        return OBJ_TRENDBYANGLE;
    }
    else if(value == "OBJ_CYCLES")
    {
        return OBJ_CYCLES;
    }
    else if(value == "OBJ_CHANNEL")
    {
        return OBJ_CHANNEL;
    }
    else if(value == "OBJ_STDDEVCHANNEL")
    {
        return OBJ_STDDEVCHANNEL;
    }
    else if(value == "OBJ_REGRESSION")
    {
        return OBJ_REGRESSION;
    }
    else if(value == "OBJ_PITCHFORK")
    {
        return OBJ_PITCHFORK;
    }
    else if(value == "OBJ_GANNLINE")
    {
        return OBJ_GANNLINE;
    }
    else if(value == "OBJ_GANNFAN")
    {
        return OBJ_GANNFAN;
    }
    else if(value == "OBJ_GANNGRID")
    {
        return OBJ_GANNGRID;
    }
    else if(value == "OBJ_FIBO")
    {
        return OBJ_FIBO;
    }
    else if(value == "OBJ_FIBOTIMES")
    {
        return OBJ_FIBOTIMES;
    }
    else if(value == "OBJ_FIBOFAN")
    {
        return OBJ_FIBOFAN;
    }
    else if(value == "OBJ_FIBOARC")
    {
        return OBJ_FIBOARC;
    }
    else if(value == "OBJ_FIBOCHANNEL")
    {
        return OBJ_FIBOCHANNEL;
    }
    else if(value == "OBJ_EXPANSION")
    {
        return OBJ_EXPANSION;
    }
    else if(value == "OBJ_RECTANGLE")
    {
        return OBJ_RECTANGLE;
    }
    else if(value == "OBJ_TRIANGLE")
    {
        return OBJ_TRIANGLE;
    }
    else if(value == "OBJ_ELLIPSE")
    {
        return OBJ_ELLIPSE;
    }
    else if(value == "OBJ_ARROW_THUMB_UP")
    {
        return OBJ_ARROW_THUMB_UP;
    }
    else if(value == "OBJ_ARROW_THUMB_DOWN")
    {
        return OBJ_ARROW_THUMB_DOWN;
    }
    else if(value == "OBJ_ARROW_UP")
    {
        return OBJ_ARROW_UP;
    }
    else if(value == "OBJ_ARROW_DOWN")
    {
        return OBJ_ARROW_DOWN;
    }
    else if(value == "OBJ_ARROW_STOP")
    {
        return OBJ_ARROW_STOP;
    }
    else if(value == "OBJ_ARROW_CHECK")
    {
        return OBJ_ARROW_CHECK;
    }
    else if(value == "OBJ_ARROW_LEFT_PRICE")
    {
        return OBJ_ARROW_LEFT_PRICE;
    }
    else if(value == "OBJ_ARROW_RIGHT_PRICE")
    {
        return OBJ_ARROW_RIGHT_PRICE;
    }
    else if(value == "OBJ_ARROW_BUY")
    {
        return OBJ_ARROW_BUY;
    }
    else if(value == "OBJ_ARROW_SELL")
    {
        return OBJ_ARROW_SELL;
    }
    else if(value == "OBJ_ARROW")
    {
        return OBJ_ARROW;
    }
    else if(value == "OBJ_TEXT")
    {
        return OBJ_TEXT;
    }
    else if(value == "OBJ_LABEL")
    {
        return OBJ_LABEL;
    }
    else if(value == "OBJ_BUTTON")
    {
        return OBJ_BUTTON;
    }
    else if(value == "OBJ_BITMAP")
    {
        return OBJ_BITMAP;
    }
    else if(value == "OBJ_BITMAP_LABEL")
    {
        return OBJ_BITMAP_LABEL;
    }
    else if(value == "OBJ_EDIT")
    {
        return OBJ_EDIT;
    }
    else if(value == "OBJ_EVENT")
    {
        return OBJ_EVENT;
    }
    else if(value == "OBJ_RECTANGLE_LABEL")
    {
        return OBJ_RECTANGLE_LABEL;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_BASE_DOUBLE(string value)
{
    if(value == "SIGNAL_BASE_BALANCE")
    {
        return SIGNAL_BASE_BALANCE;
    }
    else if(value == "SIGNAL_BASE_EQUITY")
    {
        return SIGNAL_BASE_EQUITY;
    }
    else if(value == "SIGNAL_BASE_GAIN")
    {
        return SIGNAL_BASE_GAIN;
    }
    else if(value == "SIGNAL_BASE_MAX_DRAWDOWN")
    {
        return SIGNAL_BASE_MAX_DRAWDOWN;
    }
    else if(value == "SIGNAL_BASE_PRICE")
    {
        return SIGNAL_BASE_PRICE;
    }
    else if(value == "SIGNAL_BASE_ROI")
    {
        return SIGNAL_BASE_ROI;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_BASE_INTEGER(string value)
{
    if(value == "SIGNAL_BASE_DATE_PUBLISHED")
    {
        return SIGNAL_BASE_DATE_PUBLISHED;
    }
    else if(value == "SIGNAL_BASE_DATE_STARTED")
    {
        return SIGNAL_BASE_DATE_STARTED;
    }
    else if(value == "SIGNAL_BASE_ID")
    {
        return SIGNAL_BASE_ID;
    }
    else if(value == "SIGNAL_BASE_LEVERAGE")
    {
        return SIGNAL_BASE_LEVERAGE;
    }
    else if(value == "SIGNAL_BASE_PIPS")
    {
        return SIGNAL_BASE_PIPS;
    }
    else if(value == "SIGNAL_BASE_RATING")
    {
        return SIGNAL_BASE_RATING;
    }
    else if(value == "SIGNAL_BASE_SUBSCRIBERS")
    {
        return SIGNAL_BASE_SUBSCRIBERS;
    }
    else if(value == "SIGNAL_BASE_TRADES")
    {
        return SIGNAL_BASE_TRADES;
    }
    else if(value == "SIGNAL_BASE_TRADE_MODE")
    {
        return SIGNAL_BASE_TRADE_MODE;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_BASE_STRING(string value)
{
    if(value == "SIGNAL_BASE_AUTHOR_LOGIN")
    {
        return SIGNAL_BASE_AUTHOR_LOGIN;
    }
    else if(value == "SIGNAL_BASE_BROKER")
    {
        return SIGNAL_BASE_BROKER;
    }
    else if(value == "SIGNAL_BASE_BROKER_SERVER")
    {
        return SIGNAL_BASE_BROKER_SERVER;
    }
    else if(value == "SIGNAL_BASE_NAME")
    {
        return SIGNAL_BASE_NAME;
    }
    else if(value == "SIGNAL_BASE_CURRENCY")
    {
        return SIGNAL_BASE_CURRENCY;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_INFO_DOUBLE(string value)
{
    if(value == "SIGNAL_INFO_EQUITY_LIMIT")
    {
        return SIGNAL_INFO_EQUITY_LIMIT;
    }
    else if(value == "SIGNAL_INFO_SLIPPAGE")
    {
        return SIGNAL_INFO_SLIPPAGE;
    }
    else if(value == "SIGNAL_INFO_VOLUME_PERCENT")
    {
        return SIGNAL_INFO_VOLUME_PERCENT;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_INFO_INTEGER(string value)
{
    if(value == "SIGNAL_INFO_CONFIRMATIONS_DISABLED")
    {
        return SIGNAL_INFO_CONFIRMATIONS_DISABLED;
    }
    else if(value == "SIGNAL_INFO_COPY_SLTP")
    {
        return SIGNAL_INFO_COPY_SLTP;
    }
    else if(value == "SIGNAL_INFO_DEPOSIT_PERCENT")
    {
        return SIGNAL_INFO_DEPOSIT_PERCENT;
    }
    else if(value == "SIGNAL_INFO_ID")
    {
        return SIGNAL_INFO_ID;
    }
    else if(value == "SIGNAL_INFO_SUBSCRIPTION_ENABLED")
    {
        return SIGNAL_INFO_SUBSCRIPTION_ENABLED;
    }
    else if(value == "SIGNAL_INFO_TERMS_AGREE")
    {
        return SIGNAL_INFO_TERMS_AGREE;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_INFO_STRING(string value)
{
    if(value == "SIGNAL_INFO_NAME")
    {
        return SIGNAL_INFO_NAME;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_TIMEFRAMES(string value)
{
    if(value == "PERIOD_CURRENT")
    {
        return PERIOD_CURRENT;
    }
    else if(value == "PERIOD_M1")
    {
        return PERIOD_M1;
    }
    else if(value == "PERIOD_M5")
    {
        return PERIOD_M5;
    }
    else if(value == "PERIOD_M15")
    {
        return PERIOD_M15;
    }
    else if(value == "PERIOD_M30")
    {
        return PERIOD_M30;
    }
    else if(value == "PERIOD_H1")
    {
        return PERIOD_H1;
    }
    else if(value == "PERIOD_H4")
    {
        return PERIOD_H4;
    }
    else if(value == "PERIOD_D1")
    {
        return PERIOD_D1;
    }
    else if(value == "PERIOD_W1")
    {
        return PERIOD_W1;
    }
    else if(value == "PERIOD_MN1")
    {
        return PERIOD_MN1;
    }
    else
    {
         return -1;
    }
}

