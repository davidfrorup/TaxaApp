namespace TaxaApp.JavaScript
{
    public class google_maps
    {

        function AddGoogleMapsScript(apiKey) {
        const script = document.createElement("script");
        script.src = `https://maps.googleapis.com/maps/api/js?key=${apiKey}&callback=InitializeGoogleMap`;
        script.defer = true;
        script.async = true;
        document.head.appendChild(script);
    }

    function InitializeGoogleMap() {
        // Initialiser Google Maps her (du skal tilpasse dette afhængigt af dit specifikke behov)
        // Brug dokumentationen for Google Maps JavaScript API for at tilpasse din implementation.
    }


    }
}
