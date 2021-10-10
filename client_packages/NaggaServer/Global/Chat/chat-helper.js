var activateChat = function (isActivated) {
    chatPage.active = isActivated;
    mp.gui.chat.show(isActivated);
}