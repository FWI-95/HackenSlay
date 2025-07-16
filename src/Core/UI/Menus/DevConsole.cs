using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#nullable enable

namespace HackenSlay;

public class DevConsole
{
    bool _isVisible;
    bool _togglePrev;
    Texture2D? _pixel;
    Rectangle _rect;
    string _input = string.Empty;
    readonly List<string> _history = new();
    GameHS? _game;

    public void LoadContent(GameHS game)
    {
        _game = game;
        _pixel = new Texture2D(game.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });
        int width = game.Window.ClientBounds.Width - 20;
        int height = game.Window.ClientBounds.Height / 4;
        _rect = new Rectangle(10, game.Window.ClientBounds.Height - height - 10, width, height);
        game.Window.TextInput += OnTextInput;
    }

    private void OnTextInput(object? sender, TextInputEventArgs e)
    {
        if (!_isVisible) return;
        if (e.Key == Keys.Back)
        {
            if (_input.Length > 0)
                _input = _input[..^1];
        }
        else if (e.Key == Keys.Enter)
        {
            ExecuteCommand(_input);
            _input = string.Empty;
        }
        else if (!char.IsControl(e.Character))
        {
            _input += e.Character;
        }
    }

    public void Update(GameHS game, GameTime gameTime)
    {
        bool pressed = game.userInput.IsActionPressed("dev_console");
        if (pressed && !_togglePrev)
            _isVisible = !_isVisible;
        _togglePrev = pressed;
    }

    public void Draw(GameHS game, SpriteBatch spriteBatch)
    {
        if (!_isVisible || _pixel == null) return;
        spriteBatch.Draw(_pixel, _rect, Color.Black * 0.8f);
        Vector2 pos = new Vector2(_rect.X + 10, _rect.Y + 10);
        int start = Math.Max(0, _history.Count - 5);
        for (int i = start; i < _history.Count; i++)
        {
            spriteBatch.DrawString(game._font, _history[i], pos, Color.White);
            pos.Y += 20;
        }
        spriteBatch.DrawString(game._font, "> " + _input, new Vector2(_rect.X + 10, _rect.Bottom - 30), Color.Yellow);
    }

    private void ExecuteCommand(string command)
    {
        if (_game == null || string.IsNullOrWhiteSpace(command)) return;
        _history.Add(command);
        var parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return;

        switch (parts[0].ToLower())
        {
            case "spawn":
                if (parts.Length >= 3)
                {
                    string type = parts[1].ToLower();
                    string name = parts[2];
                    switch (type)
                    {
                        case "enemy":
                            var enemy = DevSpawner.SpawnEnemy(name);
                            if (enemy != null)
                            {
                                enemy._pos = _game.player._pos + new Vector2(50, 0);
                                _game.AddObject(enemy);
                                _history.Add($"Spawned enemy {name}");
                            }
                            break;
                        case "weapon":
                            var weapon = DevSpawner.SpawnWeapon(name);
                            if (weapon != null)
                            {
                                _game.AddObject(weapon);
                                _history.Add($"Spawned weapon {name}");
                            }
                            break;
                        case "item":
                            var item = DevSpawner.SpawnItem(name);
                            if (item != null)
                            {
                                _game.AddObject(item);
                                _history.Add($"Spawned item {name}");
                            }
                            break;
                    }
                }
                break;
            case "set":
                if (parts.Length >= 4 && parts[1].ToLower() == "player")
                {
                    string attr = parts[2].ToLower();
                    string value = parts[3];
                    switch (attr)
                    {
                        case "health":
                            if (int.TryParse(value, out int h)) _game.player._health = h;
                            break;
                        case "walkspeed":
                            if (float.TryParse(value, out float ws)) _game.player._walkspeed = ws;
                            break;
                        case "runspeed":
                            if (float.TryParse(value, out float rs)) _game.player._runspeed = rs;
                            break;
                        case "strength":
                            if (int.TryParse(value, out int st)) _game.player._strength = st;
                            break;
                    }
                    _history.Add($"Set player {attr} to {value}");
                }
                else if (parts.Length >= 4 && parts[1].ToLower() == "enemy")
                {
                    string attr = parts[2].ToLower();
                    string value = parts[3];
                    foreach (var obj in _game.Objects)
                    {
                        if (obj is Enemy enemy)
                        {
                            switch (attr)
                            {
                                case "health":
                                    if (int.TryParse(value, out int eh)) enemy._health = eh;
                                    break;
                                case "strength":
                                    if (int.TryParse(value, out int es)) enemy._strength = es;
                                    break;
                            }
                        }
                    }
                    _history.Add($"Set all enemies {attr} to {value}");
                }
                break;
        }
    }
}
