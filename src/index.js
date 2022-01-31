const prompt = require('prompt-sync')({sigint:true});
const mainArt = require('./routes/articulos');
const mainUsers = require('./routes/usuarios');
var opc = prompt('Escoge una opción 1.- Articulos 2.- Usuarios');
if(parseFloat(opc) == 1){
    mainArt();
}else{
    mainUsers();
}