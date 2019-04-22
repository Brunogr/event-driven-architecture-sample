import { ProdutoModel } from './produto.model';
export class CarrinhoModel{
    Id : string;
    valorTotal : number;
    produtos: ProdutoModel[];
    comprador: Comprador;
}

export class Comprador {
    public nome: string;
}

// "comprador": {
//     "nome": "Bruno"
// },
// "valorTotal": 1797,
// "produtos": [
//     {
//         "id": "cfe00103-a8ec-4eeb-b961-02e9aea877de",
//         "nome": "Microondas Brastemp",
//         "valor": 599
//     },
//     {
//         "id": "cfe00103-a8ec-4eeb-b961-02e9aea877de",
//         "nome": "Microondas Brastemp",
//         "valor": 599
//     },
//     {
//         "id": "cfe00103-a8ec-4eeb-b961-02e9aea877de",
//         "nome": "Microondas Brastemp",
//         "valor": 599
//     }
// ]