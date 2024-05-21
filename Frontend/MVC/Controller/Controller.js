import DataService from "../Model/DataService.js";
import Pontszamok from "../Model/Pontszamok.js";
import PontSzamitasView from "../View/PontSzamitasView.js";
import SzavakView from "../View/SzavakView.js";
import TemaValasztasView from "../View/TemaValasztasView.js";

export default class Controller
{
    constructor()
    {
        const dataService = new DataService("http://localhost:5226");
        const pontszamitasView = new PontSzamitasView($("#pontszam"));
        dataService.get("tema", data => {
            new TemaValasztasView($("#tema"), data);
            $(window).on("tematValasztottEvent", event => {
                dataService.get("szavak/" + event.detail.temaId, data => {
                    const pontszamok = new Pontszamok(data);
                    new SzavakView($("#szavak"), data);
                    $(window).on("valaszValtozottEvent", event => {
                        pontszamok.setValasz("valasz" + event.detail.valaszId, event.detail.helyes);
                        pontszamitasView.pontszamKiir(pontszamok.hanyHelyes());
                    });
                });
            });
        });
    }
}