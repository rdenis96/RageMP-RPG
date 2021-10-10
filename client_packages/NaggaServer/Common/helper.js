// var disableUserControl = function (shouldDisable) {
//     if (shouldDisable) {
//         try {
//             mp.game.ui.displayRadar(false);
//             player.position = new mp.Vector3(-427.65, 1116.374, 326.8);
//             setTimeout(function () {
//                 mp.gui.cursor.show(true, true);
//             }, 10);
//             setTimeout(function () {
//                 player.freezePosition(true);
//             }, 10);
//             setTimeout(function () {
//                 mp.game.player.setInvincible(true);
//             }, 10);
//             setTimeout(function () {
//                 activateChat(false);
//             }, 1000);
//         } catch (e) {
//             console.log(e);
//         }
//     } else {
//         try {
//             mp.game.ui.displayRadar(true);
//             setTimeout(function () {
//                 mp.gui.cursor.show(false, false);
//             }, 10);
//             setTimeout(function () {
//                 player.freezePosition(false);
//             }, 10);
//             setTimeout(function () {
//                 mp.game.player.setInvincible(false);
//             }, 10);
//             setTimeout(function () {
//                 activateChat(true);
//             }, 1000);
//         } catch (e) {
//             console.log(e);
//         }
//     }
// };

// var showPage = function(canShow, clientPage = clientPages.None){
//     if(canShow){
//         mainPage.active = canShow;
//         mainPage.execute(`showPage('${clientPage}')`);
//     }
//     else{
//         mainPage.execute(`showPage('${clientPages.None}')`);
//         mainPage.active = canShow;
//     }
// }