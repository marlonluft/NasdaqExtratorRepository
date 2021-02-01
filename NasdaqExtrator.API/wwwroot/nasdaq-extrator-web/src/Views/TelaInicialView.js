import React, { Component } from 'react'

class TelaInicialView extends Component {
    render() {
        return (
            <div>
                <h2>Bem vindo</h2>

                <table>
                    <thead>
                        <tr>
                            <th colSpan={4}>Top 10 Dividendos Pagos 2020</th>
                        </tr>
                        <tr>
                            <th>Simbolo</th>
                            <th>Valor Médio Pago</th>
                            <th>Valor Total Pago</th>
                            <th>Qtd Dividendos Pagos</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>IBM</td>
                            <td>$ 0.10</td>
                            <td>$ 0.60</td>
                            <td>6</td>
                        </tr>
                        <tr>
                            <td>ERP</td>
                            <td>$ 1.0</td>
                            <td>$ 0.10</td>
                            <td>10</td>
                        </tr>
                    </tbody>
                </table>

                <table>
                    <thead>
                        <tr>
                            <th colSpan={4}>Top 10 Pagadoras Dividendos Estáveis</th>
                        </tr>
                        <tr>
                            <th>Simbolo</th>
                            <th>Valor Médio Pago</th>
                            <th>V.M. 2020</th>
                            <th>V.M. 2019</th>
                            <th>V.M. 2018</th>
                            <th>V.M. 2017</th>
                            <th>Qtd Média Dividendos Pagos</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>IBM</td>
                            <td>$ 0.10</td>
                            <td>$ 0.10</td>
                            <td>$ 0.10</td>
                            <td>$ 0.10</td>
                            <td>$ 0.10</td>
                            <td>6</td>
                        </tr>
                        <tr>
                            <td>ERP</td>
                            <td>$ 1.0</td>
                            <td>$ 0.10</td>
                            <td>$ 0.10</td>
                            <td>$ 0.10</td>
                            <td>$ 0.10</td>
                            <td>10</td>
                        </tr>
                    </tbody>
                </table>

                <table>
                    <thead>
                        <tr>
                            <th colSpan={4}>Top 10 Stock Crescentes</th>
                        </tr>
                        <tr>
                            <th>Simbolo</th>
                            <th>Cresc. 2020</th>
                            <th>Cresc. 2019</th>
                            <th>Cresc. 2018</th>
                            <th>Cresc. 2017</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>IBM</td>
                            <td>10%</td>
                            <td>10%</td>
                            <td>10%</td>
                            <td>10%</td>
                        </tr>
                        <tr>
                            <td>ERP</td>
                            <td>9%</td>
                            <td>10%</td>
                            <td>10%</td>
                            <td>10%</td>
                        </tr>
                    </tbody>
                </table>

            </div>
        )
    }
}

export default TelaInicialView