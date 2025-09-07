using System;
using System.Collections;
using HackenSlay.Core.Animation;
using HackenSlay.UI.Menus;
using Microsoft.Xna.Framework;

namespace HackenSlay.Core
{
    public enum GameState
    {
        Initializing,
        Loading,
        StartMenu,
        PauseMenu,
        Playing
    }

    public class GameStateManager
    {
        public GameState CurrentState { get; private set; } = GameState.Initializing;

        public event Action<GameState, GameState>? StateChanged;

        public void ChangeState(GameState newState)
        {
            if (CurrentState == newState)
                return;

            var previousState = CurrentState;
            CurrentState = newState;
            StateChanged?.Invoke(previousState, newState);
        }

        public bool IsInState(GameState state)
        {
            return CurrentState == state;
        }

        public void Update(GameHS _gameHS, StartMenu _startMenu, PauseMenu _pauseMenu, VisualEngine _visualEngine, GameTime gameTime)
        {
            switch (CurrentState)
            {
                case GameState.Initializing:
                    // Transition to Loading state after initialization
                    ChangeState(GameState.Loading);
                    break;

                case GameState.Loading:
                    // After loading, transition to StartMenu
                    ChangeState(GameState.StartMenu);
                    break;

                case GameState.StartMenu:
                    _startMenu.Update(_gameHS);
                    if (!_startMenu.IsActive)
                    {
                        ChangeState(GameState.Playing);
                    }
                    break;

                case GameState.PauseMenu:
                    _pauseMenu.Update(_gameHS);
                    if (!_pauseMenu.IsPaused)
                    {
                        ChangeState(GameState.Playing);
                    }
                    break;

                case GameState.Playing:
                    if (_startMenu.IsActive)
                    {
                        ChangeState(GameState.StartMenu);
                    }
                    else if (_pauseMenu.IsPaused)
                    {
                        ChangeState(GameState.PauseMenu);
                    }
                    else
                    {
                        _visualEngine.Update(_gameHS, gameTime);
                    }
                    break;
            }

            // _startMenu.Update(_gameHS);
            // _pauseMenu.Update(_gameHS, !_startMenu.IsActive && !_startMenu.JustClosed);
            // if (!_startMenu.IsActive && !_pauseMenu.IsPaused)
            //     _inventoryMenu.Update(_gameHS);

            // if (_startMenu.IsActive || _pauseMenu.IsPaused)
            //     return;

            // _visualEngine.Update(_gameHS, gameTime);
        }
        
    }
}