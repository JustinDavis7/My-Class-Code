namespace DijkstrasAlgorithm.GraphAdt
{
    public interface IEdge<TV, TE>
    {
        double Weight { get; set; }
        TE Data { get; set; }
        IVertex<TV, TE> Destination { get; set; }
    }
}