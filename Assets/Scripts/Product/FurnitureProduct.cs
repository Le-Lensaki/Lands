using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New FurnitureProduct", menuName = "SO/FurnitureProduct")]
public class FurnitureProduct : ScriptableObject
{
    [SerializeField] protected IDFurnitureProduct idFurnitureProduct;
    [SerializeField] protected string nameFurnitureProduct;
    [SerializeField] protected string discriptionFurnitureProduct;
    [SerializeField] protected List<MaterialProduct> materialFurnitureProducts;
    [SerializeField] protected Sprite icon;

    public IDFurnitureProduct GetIDFurnitureProduct => idFurnitureProduct;
    public string GetNameFurnitureProduct => nameFurnitureProduct;
    public string GetDiscriptionFurnitureProduct => discriptionFurnitureProduct;
    public List<MaterialProduct> MaterialFurnitureProducts => materialFurnitureProducts;
    public Sprite Icon => icon;
}
