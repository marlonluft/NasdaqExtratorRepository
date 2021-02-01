import { combineReducers } from 'redux'

import { DividendoPagosAnoCorrente, PagadorasDividendosEstaveis, StocksCrescentes } from './ConsolidadoReducer'

export default combineReducers({
    dividendoPagosAnoCorrente: DividendoPagosAnoCorrente,
    pagadorasDividendosEstaveis: PagadorasDividendosEstaveis,
    stocksCrescentes: StocksCrescentes,
})