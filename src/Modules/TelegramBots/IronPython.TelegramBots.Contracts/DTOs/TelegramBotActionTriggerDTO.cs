﻿using System.Text.Json;

namespace IronPython.TelegramBots.Contracts.DTOs
{
    public class TelegramBotActionTriggerDTO
    {
        public string Type { get; set; }
        public JsonDocument Params { get; set; }
    }
}
