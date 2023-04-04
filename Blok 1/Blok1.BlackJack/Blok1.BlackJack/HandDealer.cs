﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack
{
    public class HandDealer : HandBase
    {
        public void ShowAllCards()
        {
            foreach (var card in Cards)
            {
                card.FaceUp = true;
            }
        }
    }
}