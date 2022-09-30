const mainService = require('../services/mainService')

const buy = async (req, res, next) => {
    /*
 #swagger.description = 'Route for purchases.'
*/

/*
  #swagger.parameters['userId'] = {
	description: ' ID do usuário.',
    type: 'string',
    required: true,
    in: 'body',
    example: 'userID1',
  }

 #swagger.parameters['price'] = {
   description: 'Valor da compra.',
   type: 'double',
   required: true,
   in: 'body',
   example: '25',
  }
*/
 try {
    const {userId, price} = req.body;
    await mainService.buy(userId, price);
    res.sendStatus(200)
    next()
 } catch(error) {
    console.log(error)
    res.sendStatus(400) && next(error)
 }
}

module.exports = {
    buy
}