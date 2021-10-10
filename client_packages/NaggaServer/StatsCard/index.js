// var isStatsOpen = false;

// mp.keys.bind(0x71, false, function() {
//     mp.events.callRemote('keypressStats');
// });

// mp.events.add('showStats', (stats) => {
//     if (isStatsOpen === false) {
//         var statsJson = JSON.stringify(stats);
//         showPage(true, clientPages.StatsCard);
//         mainPage.execute(`executeAction('${clientPages.StatsCard}','showStatsCard','${statsJson}')`);
//         isStatsOpen = true;
//     }
//     else {
//         showPage(false);
//         isStatsOpen = false;
//     }
// });