export default class PontSzamitasView
{
    #szuloElem;

    constructor(szuloElem)
    {
        this.#szuloElem = szuloElem;
        this.#szuloElem.html("Helyes válaszok: 0");
    }

    pontszamKiir(pontszam)
    {
        this.#szuloElem.html("Helyes válaszok: " + pontszam);
    }
}