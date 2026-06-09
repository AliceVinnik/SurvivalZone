/*AliceVinnik*/

using UnityEngine;

public interface IPooled
{
    public Pool AddPool { set; }

    public void ReturnToPull();
}