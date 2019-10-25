/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication2;

import java.util.ArrayList;
import java.util.List;
import javaapplication2.Strip;

/**
 *
 * @author Brecht Bekaert
 */
public class StripCollectie implements IStripCollectie{

    private List<Strip> lijst;

    public StripCollectie() {
        lijst = new ArrayList<Strip>();    
    }
    
    @Override
    public Strip[] getStrips(String reeks) {
        Strip[] strips  = lijst.stream()
                .filter(s -> s.getReeks() == reeks)
                .sorted()
                .toArray(Strip[]::new);
        if (strips.length == 0) {
            return null;
        }  
        else {
            return strips;
        }
    }

    @Override
    public void verwijder(Strip strip) {
        lijst.remove(strip);
                
    }

    @Override
    public void voegToe(Strip strip) {
        lijst.add(strip);
    }
    
}
