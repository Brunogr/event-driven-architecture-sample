import { CarrinhoModel } from "./carrinho.model";
import { GanhadorModel } from "./ganhador.model";
import { ProdutoModel } from "./produto.model";

export class EstoqueModel{
    id : string;
    produto : ProdutoModel;
    quantidadeDisponivel : number;
}
