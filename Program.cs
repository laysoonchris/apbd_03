using apbd_03.Properties;

var ship1 = new Ship("Maria", 20, 5, 50);
var ship2 = new Ship("Teresa", 25, 10, 100);

var c1 = new KontenerC(200, 100, 100, 800, "meat", -15);
c1.fill(500);

var c2 = new KontenerG(200, 100, 100, 700, 2.5);
c2.fill(600);

// var c3 = new KontenerL(200, 100, 100, 1000,true);
// c3.fill(400);

ship1.addKontener(c1);
ship1.addKontener(c2);
// ship1.addKontener(c3);

ship1.showShip();

ship1.removeContainer(c2.serialNumber);
ship1.showShip();

ship2.addKontener(c2);
ship1.moveKontener(c1.serialNumber, ship2);

ship2.showShip();
ship2.show(c2.serialNumber);

