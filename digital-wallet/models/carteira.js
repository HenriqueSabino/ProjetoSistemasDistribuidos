const Sequelize = require('sequelize');
const database = require('../db');
 
const Carteira = database.define('carteira', {
    id: {
        type: Sequelize.INTEGER,
        autoIncrement: true,
        allowNull: false,
        primaryKey: true
    },
    userId: {
        type: Sequelize.STRING,
        allowNull: false
    },
    balance: {
        type: Sequelize.DOUBLE,
        allowNull: false
    }
})
 
module.exports = Carteira;