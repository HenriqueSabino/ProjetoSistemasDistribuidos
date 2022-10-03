const Carteira = require('../models/carteira');
const ERRORS = require('../helpers/errorsEnum')

const buy = async (userId, price) => {
    try {
        const user = await Carteira.findOne({where: {userId: userId}});
        if(user == null) {
            throw Error(ERRORS.USER_NOT_PRESENT)
        } else if(user.balance < price) {
            throw Error(ERRORS.NOT_ENOUGH_BALANCE)
        } else {
            // TO-DO: Request to save purchase on real-time database
            user.balance = user.balance - price
            await user.save();
            // TO-DO: Request to start sending product locations
            return true
        }
    } catch (error) {
        throw Error(error)
    }
}

const balance = async (userId) => {
    try {
        const user = await Carteira.findOne({where: {userId: userId}});
        console.log(userId)
        if(user == null) {
            throw Error(ERRORS.USER_NOT_PRESENT.toString())
        } else {
            return user.balance
        }
    } catch (error) {
        throw Error(error)
    }
}

module.exports = {
    buy,
    balance
}