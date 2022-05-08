using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBot.Mulligan
{
    [Serializable]
    public class DefaultMulliganProfile : MulliganProfile
    {
        List<Card.Cards> CardsToKeep = new List<Card.Cards>();

        private readonly List<Card.Cards> WorthySpells = new List<Card.Cards>
        {
            
        };

        public List<Card.Cards> HandleMulligan(List<Card.Cards> choices, Card.CClass opponentClass,
            Card.CClass ownClass)
        {
            bool HasCoin = choices.Count >= 4;

            int flag1=0;//港口匪徒 SW_029
            int flag2=0;//血帆桨手 CS3_008
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.SW_029//港口匪徒 SW_029
                ){flag1+=1;}
                if(card==Card.Cards.CS3_008//血帆桨手 CS3_008
                ){flag2+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.TSC_632// 械钳虾 TSC_632
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_632))
                    {
                        Keep(card,"械钳虾");
                    }
                }
                if(card==Card.Cards.SW_048// 棱彩珠宝工具 SW_048
                ){ if(!CardsToKeep.Contains(Card.Cards.SW_048))
                    {
                        Keep(card,"棱彩珠宝工具");
                    }
                }
                if(card==Card.Cards.SW_315// 联盟旗手 SW_315
                ){ if(!CardsToKeep.Contains(Card.Cards.SW_315))
                    {
                        Keep(card,"联盟旗手");
                    }
                }
                if(card==Card.Cards.TSC_083// 海床救生员 TSC_083
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_083))
                    {
                        Keep(card,"海床救生员");
                    }
                }
                if(card==Card.Cards.CORE_ICC_038//  正义保护者 CORE_ICC_038
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_ICC_038))
                    {
                        Keep(card,"正义保护者");
                    }
                }
                if(card==Card.Cards.ONY_022//  武装教士 ONY_022 
                ){ if(!CardsToKeep.Contains(Card.Cards.ONY_022))
                    {
                        Keep(card,"武装教士");
                    }
                }
                if(card==Card.Cards.TSC_644//  艾萨拉的观月仪 TSC_644 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_644))
                    {
                        Keep(card,"艾萨拉的观月仪");
                    }
                }
            }
            return CardsToKeep;
        }

        private void Keep(Card.Cards id, string log = "")
        {
            CardsToKeep.Add(id);
            if(log != "")
                Bot.Log(log);
        }

    }
}//德：DRUID 猎：HUNTER 法：MAGE 骑：PALADIN 牧：PRIEST 贼：ROGUE 萨：SHAMAN 术：WARLOCK 战：WARRIOR 瞎：DEMONHUNTER