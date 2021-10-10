const flipObject = obj => {
  const ret = {};
  Object.keys(obj).forEach((key) => {
    ret[obj[key]] = key;
  });
  return ret;
};

let Keys = {
  'backspace': 8,
  'tab': 9,
  'clear': 12,
  'enter': 13,
  'return': 13,
  'esc': 27,
  'escape': 27,
  'space': 32,
  'left': 37,
  'up': 38,
  'right': 39,
  'down': 40,
  'del': 46,
  'delete': 46,
  'ins': 45,
  'insert': 45,
  'home': 36,
  'end': 35,
  'pageup': 33,
  'pagedown': 34,
  'capslock': 20,
  'shift': 16,
  'alt': 18,
  'ctrl': 17,
  'control': 17,
  '-': 189,
  '=': 187,
  ',': 188,
  ';': 186,
  '.': 190,
  '/': 191,
  '`': 192,
  '\'': 222,
  '[': 219,
  ']': 221,
  '\\': 220,
  'kp_multiply': 106,
  'kp_add': 107,
  'kp_subtract': 109,
  'kp_decimal': 110,
  'kp_divide': 111,
};

// A - Z
for(let i = 65; i <= 90; i++)
  Keys[String.fromCharCode(i).toLowerCase()] = i;

// F1 - F20
for(let i = 1; i <= 20; i++)
    Keys[`f${i}`] = 111+i;

// 0 - 9
for(let i = 0; i <= 9; i++)
  Keys[`${i}`] = 48+i;

// Numpad 0 - 9
for(let i = 0; i <= 9; i++)
  Keys[`kp_${i}`] = 96+i;


let KeysMap = flipObject(Keys);

module.exports = {
  Keys,
  KeysMap,
};
