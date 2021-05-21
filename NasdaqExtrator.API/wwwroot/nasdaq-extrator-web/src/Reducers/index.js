import { combineReducers } from 'redux'

import { stockReducer } from './StockReducer'

export default combineReducers({
    stock: stockReducer,
})