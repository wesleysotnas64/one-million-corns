public enum TileState
{
    Raw0,     // Grama Claro
    Raw1,     // Grama Escuro
    Plowed0,  // Solo Arado Claro
    Plowed1   // Solo Arado Escuro
}
    
public enum ToolType
{
    Selection,    // Seleção / Mão livre
    Hoe,          // Ciscador
    Seed,         // Semente
    WateringCan,  // Regador
    Glove,        // Luva de Colheita
    Sickle        // Foice
}

public enum CornstalkState
{
    Seed,        // Semente
    Germination, // Germinação
    Sprout,      // Broto
    Young,       // Jovem
    Mature,      // Maduro
    Harvested,   // Colhido
    Dry          // Seco
}
