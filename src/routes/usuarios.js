const prompt = require('prompt-sync')({sigint:true});
const pool = require('../DB/database');
function mainUsers(){
    console.log("Hola Usuarios");
}
module.exports = mainUsers;