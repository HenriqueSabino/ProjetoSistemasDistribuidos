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

            // const realtimeDbData = {
            //     // TODO
            // };

            // const res = await axios.post('TODO: this request', realtimeDbData)
            //     .catch((err) => {
            //         console.log(err)
            //         throw Error(ERRORS.FAILED_TO_WRITE_PURCHASE);
            //     });

            user.balance = user.balance - price
            await user.save();

            const deliverySysData = {
                orderId: "bla"
            };
            
            await axios.post('http://sistema-de-envios/Parcel/Add', deliverySysData)
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