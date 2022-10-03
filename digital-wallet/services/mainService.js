const Carteira = require('../models/carteira');
const ERRORS = require('../helpers/errorsEnum')
const axios = require('axios');

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

            const data = {
                orderId: 'from_to_do_integration_with_realtime_database'
            };
            
            await axios.post('http://localhost:5000/Parcel/Add', data)
            .catch((err) => {
                console.log(err)
                throw Error(ERRORS.FAILED_TO_SEND_PURCHASE_TO_DELIVERY_SYSTEM);
            });

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