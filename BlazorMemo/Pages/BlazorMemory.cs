using BlazorMemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMemo.Pages
{
    public partial class BlazorMemory
    {
        List<CardModel> Cards = new List<CardModel>
        {
            new CardModel
            {
                FrontPath = "/img/blazor.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/blazor.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/azure.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/azure.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/c.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/c.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/netcore.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/netcore.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/office.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/office.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/vs.svg",
                BackPath = "/img/logo.svg"
            },
            new CardModel
            {
                FrontPath = "/img/vs.svg",
                BackPath = "/img/logo.svg"
            }
        };

        bool hasFlippedCard = false;

        CardModel firstCard;
        CardModel secondCard;

        bool lockBoard = false;

        private async Task CheckCards(CardModel cardModel)
        {
            if (lockBoard)
            {
                return;
            }

            if (cardModel == firstCard)
            {
                return;
            }

            cardModel.IsFlipped = true;

            if (!hasFlippedCard)
            {
                hasFlippedCard = true;
                firstCard = cardModel;
            }
            else
            {
                //hasFlippedCard = false;
                secondCard = cardModel;
                await CheckForMatch();
            }
        }

        private async Task CheckForMatch()
        {
            if (firstCard.FrontPath == secondCard.FrontPath)
            {
                DisableCards();
            }
            else
            {
                await UnFlipCards();
            }
        }

        private void DisableCards()
        {
            firstCard.CanExecute = false;
            secondCard.CanExecute = false;
            ResetBoard();
        }

        private async Task UnFlipCards()
        {
            lockBoard = true;
            await Task.Delay(1500);
            firstCard.IsFlipped = false;
            secondCard.IsFlipped = false;
            lockBoard = false;
            ResetBoard();
        }

        private void ResetBoard()
        {
            lockBoard = false;
            hasFlippedCard = false;
            firstCard = new CardModel();
            secondCard = new CardModel();
        }

        protected override void OnInitialized()
        {
            Shuffle();
        }

        private void Shuffle()
        {
            foreach (var card in Cards)
            {
                card.Order = new Random().Next(0, 1000);
            }
        }
    }
}
