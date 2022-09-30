const express = require('express');
const router = express.Router();

const mainController = require('../controllers/mainController')

/*Post buy with value*/
router.post('/buy', mainController.buy)

module.exports = router