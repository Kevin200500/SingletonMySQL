const prompt = require('prompt-sync')({sigint:true});
const pool = require('../DB/database');
function mainArt(){
    mostrarDatos();
}
async function mostrarDatos(){
    await pool.query('SELECT * FROM Articulos',(err,rows,columns)=>{
        if(!err){
            for(let i = 0; i < rows.length; i++){
                console.log(rows[i]);
            }
        } 
    });
}
module.exports = main = () =>{
    console.log("Hola Articulos");
};