import API from '../Util/API'

export const LISTAR_Stock = 'LISTAR_Stock'

function ListarStocks(lista) {
    return {
        type: LISTAR_Stock,
        lista,
    }
}

export function handleListarStocks() {

    return (dispatch) => {

        return API.get('https://localhost:44318/stock')
            .then((lista) => {
                dispatch(ListarStocks(lista))
            })
            .catch((e) => {
                alert('Ocorreu um erro ao listar os stocks. Tente novamente.')
            })
    }
}