import { HomeComponent } from './home/home.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule, Component, ModuleWithProviders } from '@angular/core';
const appRoutes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes, {useHash: true })],
  // Exportar modulo rota
  exports: [RouterModule]
})
export class AppRoutingModule { }

