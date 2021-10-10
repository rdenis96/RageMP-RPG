const {Keys} = require('./NaggaServer/BetterKeyBindings/Keys.js');

class BetterBinding {
  constructor() {
    this.pressedKeys = {};
    this.binds = {};
    this.keyListeners = {};
    this.modifiers = [
      Keys['ctrl'],
      Keys['alt'],
      Keys['shift'],
    ];
  }

  _handleKeyDown(keyCode) {
    this.pressedKeys[keyCode] = true;
    Object.values(this.binds).filter(b => b.modifiers.includes(keyCode) || b.key === keyCode).forEach(bind => {
      if((bind.modifiers.length > 0 &&bind.modifiers.filter(m => !this.pressedKeys[m]).length === 0 &&this.pressedKeys[bind.key]) || bind.modifiers.length === 0) {
        bind.handlers.filter(h => !h.onUp).forEach(h => h.handler());
      }
    });
  }

  _handleKeyUp(keyCode) {
    delete this.pressedKeys[keyCode];
    Object.values(this.binds).filter(b => b.key === keyCode).forEach(bind => {
      bind.handlers.filter(h => h.onUp).forEach(h => h.handler());
    });
  }


  bind(keys, handler, onUp) {
    keys = keys.toLowerCase();
    onUp = onUp || false;
    let modifiers = keys.split(/\+/);
    let key = modifiers.pop();

    if(Keys[key]) {
      key = Keys[key];
    } else {
      throw new Error(`${key} is not a valid key!`);
    }

    for(let i = 0; i < modifiers.length; i++) {
      if (Keys[modifiers[i]] && this.modifiers.includes(Keys[modifiers[i]])) {
        modifiers[i] = Keys[modifiers[i]];
      } else {
        throw new Error(`${modifiers[i]} is not a valid modifier!`);
      }
    }

    if(onUp && modifiers.length > 0) {
      throw new Error("The keyup-event doesn't support modifiers!");
    }

    if(this.binds[keys]) {
      this.binds[keys].handlers.push({
        handler,
        onUp
      });
    } else {
      [...modifiers, key].filter(k => !this.keyListeners.hasOwnProperty(k)).forEach(k => this._startKeyListener(k));

      this.binds[keys] = {
        modifiers,
        key,
        handlers: [{
          handler,
          onUp
        }],
      };
    }

    return () => {
      this.unbind(keys, handler);
    }
  }

  unbind(keys, handler) {
    keys = keys.toLowerCase();
    let bind = this.binds[keys];
    if(bind) {
      let indexToDelete = bind.handlers.indexOf(handler);
      if(indexToDelete !== -1) {
        bind.handlers.splice(indexToDelete, 1);
        if(bind.handlers.length === 0) {
          delete this.binds[keys];
          this._cleanKeyListeners([...bind.modifiers, bind.key]);
        }
      }
    }
  }

  _startKeyListener(keyCode) {
    this.keyListeners[keyCode] = {
      downHandler: () => {
        this._handleKeyDown(keyCode);
      },
      upHandler: () => {
        this._handleKeyUp(keyCode);
      },
    };

    mp.keys.bind(keyCode, true, this.keyListeners[keyCode].downHandler);
    mp.keys.bind(keyCode, false, this.keyListeners[keyCode].upHandler);
  }

  _stopKeyListener(keyCode) {
    if(this.keyListeners[keyCode]) {
      mp.keys.unbind(keyCode, true, this.keyListeners[keyCode].downHandler);
      mp.keys.unbind(keyCode, false, this.keyListeners[keyCode].upHandler);
      delete this.keyListeners[keyCode];
    }
  }

  _cleanKeyListeners(keys) {
    keys.filter(key => Object.values(this.binds).filter(b => b.modifiers.includes(key) || b.key === key).length === 0).forEach(key => {
      this._stopKeyListener(key);
    });
  }

  addModifier(key) {
    if(Keys[key]) {
      key = Keys[key];
    } else {
      throw new Error(`${key} is not a valid key!`);
    }

    if(!this.modifiers.includes(key)){
      this.modifiers.push(key);
    }
  }

  delModifier(key) {
    if(Keys[key]) {
      key = Keys[key];
    } else {
      throw new Error(`${key} is not a valid key!`);
    }

    if(!this.modifiers.indexOf(key) !== -1){
      this.modifiers.splice(this.modifiers.indexOf(key), 1);
    }
  }

}

const betterBinding = new BetterBinding();

module.exports = module.exports.BetterBindings = betterBinding;
module.exports.Keys = Keys;
