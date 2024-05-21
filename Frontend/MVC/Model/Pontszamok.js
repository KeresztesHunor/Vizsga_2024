export default class Pontszamok
{
    #valaszok;

    constructor(szavak)
    {
        this.#valaszok = {};
        szavak.forEach(szo => {
            this.#valaszok["valasz" + szo.id] = false;
        });
    }

    hanyHelyes()
    {
        let helyesek = 0;
        for (const key in this.#valaszok)
        {
            if (this.#valaszok[key])
            {
                helyesek++;
            }
        }
        return helyesek;
    }

    setValasz(valaszIndex, ertek)
    {
        this.#valaszok[valaszIndex] = ertek;
    }
}