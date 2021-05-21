import {
    LISTAR_Stock,
} from '../Actions/StockAction'

const initialState = {
    stocks: []
}

export function consolidadoReducer(state = initialState, action) {
    switch (action.type) {
        case LISTAR_Stock:
            return {
                ...state, 
                stocks: action.lista
            }
        default:
            return state
    }
}