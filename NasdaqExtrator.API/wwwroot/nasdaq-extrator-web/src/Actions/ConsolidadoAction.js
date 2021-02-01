import API from '../Util/API'

export const LISTAR_TopDividendoPagosAnoCorrente = 'LISTAR_TopDividendoPagosAnoCorrente'
export const LISTAR_TopPagadorasDividendosEstaveis = 'LISTAR_TopPagadorasDividendosEstaveis'
export const LISTAR_TopStocksCrescentes = 'LISTAR_TopStocksCrescentes'

function ListarTopDividendoPagosAnoCorrente(lista) {
    return {
        type: LISTAR_TopDividendoPagosAnoCorrente,
        lista,
    }
}

function ListarTopPagadorasDividendosEstaveis(lista) {
    return {
        type: LISTAR_TopPagadorasDividendosEstaveis,
        lista,
    }
}

function ListarTopStocksCrescentes(lista) {
    return {
        type: LISTAR_TopStocksCrescentes,
        lista,
    }
}

export function handleTopDividendoPagosAnoCorrente() {

    return (dispatch) => {

        return API.get('https://localhost:44318/consolidado/TopDividendoPagosAnoCorrente')
            .then((lista) => {
                dispatch(ListarTopDividendoPagosAnoCorrente(lista))
            })
            .catch((e) => {
                alert('Ocorreu um erro ao listar top dividendos do ano corrente. Tente novamente.')
            })
    }
}

export function handleTopPagadorasDividendosEstaveis() {

    return (dispatch) => {

        return API.get('https://localhost:44318/consolidado/TopPagadorasDividendosEstaveis')
            .then((lista) => {
                dispatch(ListarTopPagadorasDividendosEstaveis(lista))
            })
            .catch((e) => {
                alert('Ocorreu um erro ao listar top pagadoras de dividendos estáveis. Tente novamente.')
            })
    }
}

export function handleTopStocksCrescentes() {

    return (dispatch) => {

        return API.get('https://localhost:44318/consolidado/TopStocksCrescentes')
            .then((lista) => {
                dispatch(ListarTopStocksCrescentes(lista))
            })
            .catch((e) => {
                alert('Ocorreu um erro ao listar top stocks crescentes. Tente novamente.')
            })
    }
}