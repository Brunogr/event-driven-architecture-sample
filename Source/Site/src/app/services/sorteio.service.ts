import { AppService } from "../app.service";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { SorteioModel } from "../models/sorteio.model";

@Injectable()
export class SorteioService extends AppService<SorteioModel>{
    
    constructor(http: HttpClient) {
        super(http);
      }

    async sortear() : Promise<SorteioModel>{
        var sorteio = await this.postAsync("sorteio",null);

        return <SorteioModel>sorteio;
    }
}