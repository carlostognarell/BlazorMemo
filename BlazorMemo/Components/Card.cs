using BlazorMemo.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMemo.Components
{
    public partial class Card
    {
        [Parameter]
        public CardModel CardModel { get; set; }

        [Parameter]
        public EventCallback OnPressed { get; set; }

        private void Toggle()
        {
            OnPressed.InvokeAsync(new EventArgs());

        }
    }
}
