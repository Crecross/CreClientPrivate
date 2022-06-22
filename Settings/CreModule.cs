using VRC;
using VRC.Core;

namespace CreClient
{
    public abstract class CreModule
    {
        public bool state = false;
        public void SetState(bool? n_state = null)
        {
            if ((n_state ?? !state) == state) return;
            state = n_state ?? !state;
            OnStateChange(state);
        }
        
        public virtual void OnStart() { }
        public virtual void OnStop() { }
        public virtual void OnUpdate() { }
        public virtual void OnPlayerLoaded() { }
        public virtual void OnStateChange(bool state) { }
        public virtual void OnPlayerJoined(Player player) { }
        public virtual void OnPlayerLeft(Player player) { }
        public virtual void OnWorldLoaded(ApiWorld world, ApiWorldInstance instance) { }
        public virtual void OnLeftRoom() { }
        public virtual void HudInitialized() { }
        public virtual void QuickMenuInitialized() { }
        public virtual void SocialMenuInitialized() { }
        public virtual void ActionMenuInitialized() { }
        //public virtual void WingInitialized(BaseWing wing) { }
        }
}