const express = require('express');
const router = express.Router();

const mainController = require('../controllers/mainController')

/*Post buy with value*/
router.post('/buy', mainController.buy)

/*Get balance from user*/
router.get('/balance', mainController.balance)

module.exports = router