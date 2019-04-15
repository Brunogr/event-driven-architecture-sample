import { CartelaModel } from "./cartela.model";
import { GanhadorModel } from "./ganhador.model";

export class SorteioModel{
    Id : number;
    Numero : number;
    Data : Date;
    Ganhadores : GanhadorModel[];
}
