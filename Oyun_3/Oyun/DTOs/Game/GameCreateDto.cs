﻿using Oyun.Entities;
using Oyun.Enums;

namespace Oyun.DTOs.Game;
public class GameCreateDto
{
    public GameLevel GameLevel { get; set; }
    public int FailCount { get; set; }
    public int SkipCount { get; set; }
    public int Seconds { get; set; }
    public string LanguageCode { get; set; } = "az";
}