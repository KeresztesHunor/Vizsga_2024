export default class SzavakView
{
    constructor(szuloElem, szavak)
    {
        szuloElem.html("");
        szavak.forEach(szo => {
            szuloElem.append(`
                <div>
                    <div>${szo.angol}</div>
                    <div>
                        <input type="text" />
                    </div>
                    <div class="visszajelzes"></div>
                </div>
            `);
            const visszajelzes = szuloElem.find(".visszajelzes");
            szuloElem.find("input").on("input", function(event) {
                const helyes = this.value.toLowerCase() === szo.magyar.toLowerCase();
                window.dispatchEvent(new CustomEvent("valaszValtozottEvent", {
                    detail: {
                        valaszId: szo.id,
                        helyes: helyes
                    }
                }));
                visszajelzes.html(helyes ? "✅" : "❌");
            });
        });
    }
}