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

            user.balance = user.balance - price

            const response = await axios.post('http://sistema-de-envios/Parcel/Add', {})
                .catch((err) => {
                    console.log(err)
                    throw Error(ERRORS.FAILED_TO_SEND_PURCHASE_TO_DELIVERY_SYSTEM);
                });

            // const realtimeDbData = {
            //     "quantity": 3,
            //     "parcel": response.data.id,
            //     "user": 1,
            //     "product": 1
            // };

            // await axios.post('http://inventory/orders', realtimeDbData)
            //     .catch((err) => {
            //         console.log(err)
            //         throw Error(ERRORS.FAILED_TO_WRITE_PURCHASE);
            //     });

            await user.save();

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