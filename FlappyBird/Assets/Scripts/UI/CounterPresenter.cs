using GameCore;

namespace UI
{
    public sealed class CounterPresenter
    {
        private readonly CounterView _view;

        private readonly PassedObstaclesCounter _obstaclesCounter;

        public CounterPresenter(
            CounterView view,
            PassedObstaclesCounter obstaclesCounter)
        {
            _view = view;
            _obstaclesCounter = obstaclesCounter;
        }

        public void Show()
        {
            SetValue(_obstaclesCounter.Count);

            _obstaclesCounter.OnCountChanged += SetValue;
        }

        public void Hide()
        {
            _obstaclesCounter.OnCountChanged -= SetValue;
        }

        private void SetValue(int value)
        {
            _view.SetValue(value.ToString());
        }
    }
}