export default class TemaValasztasView
{
    constructor(szuloElem, temak)
    {
        szuloElem.html(`
            <select>${(() => {
                let txt = "";
                temak.forEach(tema => {
                    txt += `<option value="${tema.id}">${tema.temaNev}</option>`;
                });
                return txt;
            })()}</select>
        `);
        szuloElem.children("select").on("change", function(event) {
            window.dispatchEvent(new CustomEvent("tematValasztottEvent", { detail: { temaId: this.value } }));
        });
    }
}