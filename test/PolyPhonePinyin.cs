using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BlueChips.RTQuote.Client
{
    class PolyPhonePinyin
    {
        public static string getchise(string cStr) 
        {
            string str = "";
            string[] sss = GetSpellCode(cStr);
            for (int i = 0; i < sss.Length;i++ ) 
            {
                str += sss[i] + ";";
            }
            return str;
        }
        /// <summary> 
        /// ��ָ�����ַ����б�CnStr�м�������ƴ�������ַ��� 
        /// </summary> 
        /// <param name="CnStr">�����ַ���</param> 
        /// <returns>���Ӧ�ĺ���ƴ������ĸ��</returns> 
        public static string[] GetSpellCode(string CnStr)
        {           
            CnStr = Regex.Replace(CnStr, "\\s", "");

            string ReturnStr = ResolvePinyinString(CnStr);

            string[] strArray = ReturnStr.Split(",;".ToCharArray());

            return strArray;
        }

        private static string ResolvePinyinString(string HanZiStr)
        //��ȡ�����ַ�����ƴ������ĸ����������
        {
            int i, j, k, m;
            string tmpStr;
            string returnStr = "";  //�������ս�����ַ���
            string[] tmpArr;
            for (i = 0; i < HanZiStr.Length; i++)
            {   //�������ַ���,��ÿ�����ֵ�����ĸ����һ��ѭ��
                tmpStr = GetCharSpellCode((char)HanZiStr[i]);   //��ȡ��i�����ֵ�ƴ������ĸ,����Ϊ1������
                if (tmpStr.Length > 0)
                {   //���ֵ�ƴ������ĸ���ڵ�����Ž��в���
                    if (returnStr != "")
                    {   //���ǵ�һ������
                        Regex regex = new Regex(",");
                        tmpArr = regex.Split(returnStr);
                        returnStr = "";
                        for (k = 0; k < tmpArr.Length; k++)
                        {
                            for (j = 0; j < tmpStr.Length; j++)    //�Է��ص�ÿ������ĸ����ƴ��
                            {
                                string charcode = tmpStr[j].ToString(); //ȡ����j��ƴ����ĸ
                                returnStr += tmpArr[k] + charcode + ",";
                            }
                        }
                        if (returnStr != "")
                            returnStr = returnStr.Substring(0, returnStr.Length - 1);
                    }
                    else
                    {   //�����һ�����ַ��ؽ��
                        for (m = 0; m < tmpStr.Length - 1; m++)
                            returnStr += tmpStr[m] + ",";
                        returnStr += tmpStr[tmpStr.Length - 1];
                    }
                }
            }
            return returnStr;   //���ش������ַ������ԣ��ָ�ÿ��ƴ�����
        }


        /// <summary> 
        /// ��ȡ�������ֶ�Ӧ��ƴ�����ַ��ַ�����
        /// </summary> 
        /// <param name="CnChar">��������</param> 
        /// <returns>������д��ĸ</returns> 
        private static string GetCharSpellCode(char HanZi)      
        {
            //�˴���¼��375��������
            string MultiPinyin = "19969:DZ,19975:WM,19988:QJ,20048:YL,20056:SC,20060:NM,20094:QG,20127:QJ,20167:QC,20193:YG,20250:KH,20256:ZC,20282:SC,20285:QJG,20291:TD,20314:YD,20340:NE,20375:TD,20389:YJ,20391:CZ,20415:PB,20446:YS,20447:SQ,20504:TC,20608:KG,20854:QJ,20857:ZC,20911:PF,20504:TC,20608:KG,20854:QJ,20857:ZC,20911:PF,20985:AW,21032:PB,21048:XQ,21049:SC,21089:YS,21119:JC,21242:SB,21273:SC,21305:YP,21306:QO,21330:ZC,21333:SDC,21345:QK,21378:CA,21397:SC,21414:XS,21442:SC,21477:JG,21480:TD,21484:ZS,21494:YX,21505:YX,21512:HG,21523:XH,21537:PB,21542:PF,21549:KH,21571:E,21574:DA,21588:TD,21589:O,21618:ZC,21621:KHA,21632:ZJ,21654:KG,21679:LKG,21683:KH,21710:A,21719:YH,21734:WOE,21769:A,21780:WN,21804:XH,21834:A,21899:ZD,21903:RN,21908:WO,21939:ZC,21956:SA,21964:YA,21970:TD,22003:A,22031:JG,22040:XS,22060:ZC,22066:ZC,22079:MH,22129:XJ,22179:XA,22237:NJ,22244:TD,22280:JQ,22300:YH,22313:XW,22331:YQ,22343:YJ,22351:PH,22395:DC,22412:TD,22484:PB,22500:PB,22534:ZD,22549:DH,22561:PB,22612:TD,22771:KQ,22831:HB,22841:JG,22855:QJ,22865:XQ,23013:ML,23081:WM,23487:SX,23558:QJ,23561:YW,23586:YW,23614:YW,23615:SN,23631:PB,23646:ZS,23663:ZT,23673:YG,23762:TD,23769:ZS,23780:QJ,23884:QK,24055:XH,24113:DC,24162:ZC,24191:GA,24273:QJ,24324:NL,24377:TD,24378:QJ,24439:PF,24554:ZS,24683:TD,24694:WE,24733:LK,24925:TN,25094:ZG,25100:XQ,25103:XH,25153:PB,25170:PB,25179:KG,25203:PB,25240:ZS,25282:FB,25303:NA,25324:KG,25341:ZY,25373:WZ,25375:XJ,25384:A,25457:A,25528:SD,25530:SC,25552:TD,25774:ZC,25874:ZC,26044:YW,26080:WM,26292:PB,26333:PB,26355:ZY,26366:CZ,26397:ZC,26399:QJ,26415:ZS,26451:SB,26526:ZC,26552:JG,26561:TD,26588:JG,26597:CZ,26629:ZS,26638:YL,26646:XQ,26653:KG,26657:XJ,26727:HG,26894:ZC,26937:ZS,26946:ZC,26999:KJ,27099:KJ,27449:YQ,27481:XS,27542:ZS,27663:ZS,27748:TS,27784:SC,27788:ZD,27795:TD,27812:O,27850:PB,27852:MB,27895:SL,27898:PL,27973:QJ,27981:KH,27986:HX,27994:XJ,28044:YC,28065:WG,28177:SM,28267:QJ,28291:KH,28337:ZQ,28463:TL,28548:DC,28601:TD,28689:PB,28805:JG,28820:QG,28846:PB,28952:TD,28975:ZC,29100:A,29325:QJ,29575:SL,29602:FB,30010:TD,30044:CX,30058:PF,30091:YSP,30111:YN,30229:XJ,30427:SC,30465:SX,30631:YQ,30655:QJ,30684:QJG,30707:SD,30729:XH,30796:LG,30917:PB,31074:NM,31085:JZ,31109:SC,31181:ZC,31192:MLB,31293:JQ,31400:YX,31584:YJ,31896:ZN,31909:ZY,31995:XJ,32321:PF,32327:ZY,32418:HG,32420:XQ,32421:HG,32438:LG,32473:GJ,32488:TD,32521:QJ,32527:PB,32562:ZSQ,32564:JZ,32735:ZD,32793:PB,33071:PF,33098:XL,33100:YA,33152:PB,33261:CX,33324:BP,33333:TD,33406:YA,33426:WM,33432:PB,33445:JG,33486:ZN,33493:TS,33507:QJ,33540:QJ,33544:ZC,33564:XQ,33617:YT,33632:QJ,33636:XH,33637:YX,33694:WG,33705:PF,33728:YW,33882:SR,34067:WM,34074:YW,34121:QJ,34255:ZC,34259:XL,34425:JH,34430:XH,34485:KH,34503:YS,34532:HG,34552:XS,34558:YE,34593:ZL,34660:YQ,34892:XH,34928:SC,34999:QJ,35048:PB,35059:SC,35098:ZC,35203:TQ,35265:JX,35299:JX,35782:SZ,35828:YS,35830:E,35843:TD,35895:YG,35977:MH,36158:JG,36228:QJ,36426:XQ,36466:DC,36710:JC,36711:ZYG,36767:PB,36866:SK,36951:YW,37034:YX,37063:XH,37218:ZC,37325:ZC,38063:PB,38079:TD,38085:QY,38107:DC,38116:TD,38123:YD,38224:HG,38241:XTC,38271:ZC,38415:YE,38426:KH,38461:YD,38463:AE,38466:PB,38477:XJ,38518:YT,38551:WK,38585:ZC,38704:XS,38739:LJ,38761:GJ,38808:SQ,39048:JG,39049:XJ,39052:HG,39076:CZ,39271:XT,39534:TD,39552:TD,39584:PB,39647:SB,39730:LG,39748:TPB,40109:ZQ,40479:ND,40516:HG,40536:HG,40583:QJ,40765:YQ,40784:QJ,40840:YK,40863:QJG,";
            string resStr = "";
            int i, j, uni;
            uni = (UInt16)HanZi;
            if (uni > 40869 || uni < 19968)
                return resStr;
            //���ظ��ַ���Unicode�ַ����еı���ֵ
            i = MultiPinyin.IndexOf(uni.ToString());
            //����Ƿ��Ƕ�����,�ǰ������ִ���,���Ǿ�ֱ����strChineseFirstPY�ַ������Ҷ�Ӧ������ĸ
            if (i < 0)
            //��ȡ�Ƕ����ֺ�������ĸ
            {
                resStr = GetSingleCharSpellCode(HanZi.ToString());

            }
            else
            {   //��ȡ�����ֺ�������ĸ
                j = MultiPinyin.IndexOf(",", i);
                resStr = MultiPinyin.Substring(i + 6, j - i - 6);
            }
            return resStr;
        }


        /// <summary> 
        /// �õ�һ���Ƕ����ֺ��ֵ�ƴ����һ����ĸ�������һ��Ӣ����ĸ��ֱ�ӷ��ش�д��ĸ 
        /// </summary> 
        /// <param name="CnChar">��������</param> 
        /// <returns>������д��ĸ</returns> 
        private static string GetSingleCharSpellCode(string CnChar)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //�������ĸ����ֱ�ӷ��� 
            if (ZW.Length == 1)
            {
                return CnChar.ToUpper();
            }
            else
            {
                // get the array of byte from the single char 
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }

            //expresstion 
            //table of the constant list 
            // 'A'; //45217..45252 
            // 'B'; //45253..45760 
            // 'C'; //45761..46317 
            // 'D'; //46318..46825 
            // 'E'; //46826..47009 
            // 'F'; //47010..47296 
            // 'G'; //47297..47613 

            // 'H'; //47614..48118 
            // 'J'; //48119..49061 
            // 'K'; //49062..49323 
            // 'L'; //49324..49895 
            // 'M'; //49896..50370 
            // 'N'; //50371..50613 
            // 'O'; //50614..50621 
            // 'P'; //50622..50905 
            // 'Q'; //50906..51386 

            // 'R'; //51387..51445 
            // 'S'; //51446..52217 
            // 'T'; //52218..52697 
            //û��U,V 
            // 'W'; //52698..52979 
            // 'X'; //52980..53640 
            // 'Y'; //53689..54480 
            // 'Z'; //54481..55289 

            // iCnChar match the constant 
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }

            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return ("?");
        }


    }
}
