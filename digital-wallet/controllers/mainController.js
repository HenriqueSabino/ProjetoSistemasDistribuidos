const ERRORS = require('../helpers/errorsEnum');
const mainService = require('../services/mainService')

const buy = async (req, res, next) => {
    /*
 #swagger.description = 'Route for purchases.'
*/
// #swagger.responses[400] = { description: '{ message: "Error: NOT_ENOUGH_BALANCE" } \n { message: "Error: USER_NOT_PRESENT" } \n { message: "Error: FAILED_TO_WRITE_PURCHASE" } \n ' }
 try {
    /*
  #swagger.parameters['body'] = {
	description: ' ID do usuário.',
    type: 'string',
    required: true,
    in: 'body',
    schema: {
        userId: 'user1',
        price: 25,
    },
  }
*/
    const {userId, price} = req.body;
    await mainService.buy(userId, price);
    res.sendStatus(200)
    next()
 } catch(error) {
    console.log(error)
    res.status(400).send({message: error.message})
 }
}

const balance = async (req, res, next) => {
    /*
 #swagger.description = 'Route for balance.'
*/

// #swagger.responses[200] = { description: '{ balance: 100 }' }

// #swagger.responses[400] = { description: '{ message: "Error: NOT_ENOUGH_BALANCE" } \n { message: "Error: USER_NOT_PRESENT" } \n { message: "Error: FAILED_TO_WRITE_PURCHASE" } \n ' }

/*
  #swagger.parameters['userId'] = {
	description: ' ID do usuário.',
    type: 'string',
    required: true,
    in: 'query',
    example: 'userID1',
  }
*/

 try {
    const {userId} = req.query;
    const balanceRes = await mainService.balance(userId);
    const response = {
        balance: balanceRes
    }
    res.send(response)
    next()
 } catch(error) {
    console.log(error.message)
    res.status(400).send({message: error.message})
 }
}

module.exports = {
    buy,
    balance
}