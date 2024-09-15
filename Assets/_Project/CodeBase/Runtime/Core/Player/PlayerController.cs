using System;
using Main.Assets._Project.CodeBase.Runtime.Core.Player.Views;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Player
{
    public class PlayerController
    {
        public event Action PlayerReachedZeroHealth;

        private readonly PlayerModel _model;
        private readonly PlayerHealthView _healthView;
        private readonly PlayerDamageView _playerDamageView;
        private readonly PlayerScoreView _scoreView;

        private bool _isActive;

        public PlayerController(PlayerModel model, PlayerHealthView healthView, 
            PlayerScoreView scoreView, PlayerDamageView playerDamageView)
        {
            _model = model;
            _healthView = healthView;
            _scoreView = scoreView;
            _playerDamageView = playerDamageView;

            InitViews();
        }

        public void Enable() => _isActive = true;

        public void Disable() => _isActive = false;

        public bool CanMove() => _isActive;

        public void AddScore(int scoreValue)
        {
            if (scoreValue <= 0 || !_isActive)
                return;

            _model.Score += scoreValue;

            UpdateScoreView();
        }

        public void ApplyDamage(int damageValue)
        {
            if (damageValue <= 0 || !_isActive)
                return;

            _model.Health -= damageValue;

            CheckZeroHealth();
            UpdateHealthView();
            VisualizeDamage();
        }

        private void CheckZeroHealth()
        {
            if (_model.Health <= 0)
            {
                _model.Health = 0;
                PlayerReachedZeroHealth?.Invoke();
            }
        }

        private void InitViews()
        {
            _healthView.Init(startHealth: _model.Health);
        }

        private void UpdateHealthView() => _healthView.UpdateCount(_model.Health);

        private void VisualizeDamage() => _playerDamageView.VisualizeDamage();

        private void UpdateScoreView() => _scoreView.UpdateCount(_model.Score);
    }
}
